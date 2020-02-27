using System;
using System.Collections.Generic;
using System.Linq;
using ORP.Models;
using ORP.Models.Enums;
using ORPCore.Business.Extensions;
using ORPCore.Business.Services;
using ORPCore.Models;
using ORPCore.Models.Enums;

namespace ORPCore.Business
{
	public class RoutePlannerGraph
	{
		private readonly City _cityFrom;
		private readonly City _cityTo;
		private readonly RouteService _routeService;
		private readonly Parcel _parcel;

		private List<GraphNode> _visitedNodes = new List<GraphNode>();
		private List<GraphNode> _openNodes = new List<GraphNode>();

		private List<GraphNode> _route;

		private GraphNode _startNode;
		private GraphNode _endNode;

		public RoutePlannerGraph(City cityFrom, City cityTo, RouteService routeService, Parcel parcel)
		{
			_cityFrom = cityFrom;
			_cityTo = cityTo;
			_routeService = routeService;
			_parcel = parcel;
			_startNode = new GraphNode(cityFrom, null, new ConnectionData());
		}

		public List<Order> ComputeRoutes()
		{
			// TODO: Add functionality and return fastest + cheapest route
			var orders = new List<Order>();
			var fastestRoute = ComputeRoute(RoutePriorityType.Fastest);
			var cheapestRoute = ComputeRoute(RoutePriorityType.Cheapest);
			orders.Add(fastestRoute);

			if (fastestRoute != cheapestRoute)
				orders.Add(cheapestRoute);

			return orders;
		}

		private void EvaluateNode(GraphNode currentNode, RoutePriorityType routePriorityType)
		{
			var connections = _routeService.GetConnectionsForCity(currentNode.City);

			foreach (var connection in connections)
			{
				var nextCity = connection.CityOne == currentNode.City ? connection.CityTwo : connection.CityOne;
				if (!nextCity.Valid)
					continue;

				if (_visitedNodes.FirstOrDefault(n => n.City.Equals(nextCity)) != null)
					continue;

				ConnectionData connectionData;
				switch (connection.ConnectionType)
				{
					case ConnectionType.Boat:
						connectionData = _routeService.GetConnectionDataBoat(_parcel);
						break;
					case ConnectionType.Car:
						connectionData = _routeService.GetConnectionDataCar(_parcel);
						break;
					default:
						connectionData = _routeService.GetConnectionData(_parcel, out string message);
						break;
				}

				if (connectionData == null)
					continue;

				var nextNodeCost = currentNode.ConnectionData.Add(connectionData);

				var node = _openNodes.FirstOrDefault(n => n.City.Equals(nextCity));
				if (node == null)
				{
					_openNodes.Add(new GraphNode(nextCity, currentNode, nextNodeCost));
				}
				else
				{
					var nextNodeScaledPrice = nextNodeCost.Price + node.ExtraCost.Sum(x => x * nextNodeCost.Price);
					if ((routePriorityType == RoutePriorityType.Cheapest && node.ScaledPrice > nextNodeScaledPrice)
					    || node.ConnectionData.Duration > nextNodeCost.Duration)
					{
						node.ConnectionData = nextNodeCost;
						node.CameFrom = currentNode;
						node.ScaledPrice = nextNodeScaledPrice;
					}
				}
			}
		}

		private void GenerateRoute(GraphNode currentNode)
		{
			if (currentNode == null)
				return;
			GenerateRoute(currentNode.CameFrom);
			_route.Add(currentNode);
		}

		private Order ComputeRoute(RoutePriorityType routePriorityType)
		{
			_visitedNodes = new List<GraphNode>();
			_openNodes = new List<GraphNode> { _startNode };
			_route = new List<GraphNode>();

			while (_openNodes.Count > 0)
			{
				var currentNode = _openNodes.OrderBy(n => n.ConnectionData.Price).First();
				if (currentNode.City.Equals(_cityTo))
				{
					_endNode = currentNode;
					GenerateRoute(currentNode);
					break;
				}

				EvaluateNode(currentNode, routePriorityType);

				_visitedNodes.Add(currentNode);
				_openNodes.Remove(currentNode);
			}

			return new Order()
			{
				CityFrom = _cityFrom,
				CityTo = _cityTo,
				Duration = _endNode.ConnectionData.Duration,
				OrderTime = DateTime.UtcNow,
				Parcel = _parcel,
				Price = _endNode.ScaledPrice
			};
		}
	}
}