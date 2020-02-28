using System;
using System.Collections.Generic;
using System.Linq;
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
			if (!_cityFrom.Valid || !_cityTo.Valid)
				return new List<Order>();

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
				var nextCityName = connection.CityOne == currentNode.City.Name
					? connection.CityTwo
					: connection.CityOne;
				if (_visitedNodes.FirstOrDefault(n => n.City.Name.Equals(nextCityName)) != null)
					continue;

				var nextCity = _routeService.GetCity(nextCityName);
				if (!nextCity.Valid)
					continue;

				ConnectionData connectionData;
				switch (connection.ConnectionType)
				{
					case ConnectionType.Boat:
						connectionData = _routeService.GetConnectionDataBoat(_parcel, _cityFrom, _cityTo);
						break;
					case ConnectionType.Car:
						connectionData = _routeService.GetConnectionDataCar(_parcel, _cityFrom, _cityTo);
						break;
					default:
						connectionData = _routeService.GetConnectionData(_parcel, out string message);
						break;
				}

				if (connectionData == null)
					continue;

				var nextNodeCost = currentNode.ConnectionData.Add(connectionData);

				var node = _openNodes.FirstOrDefault(n => n.City.Name.Equals(nextCityName));
				if (node == null)
				{
					_openNodes.Add(new GraphNode(nextCity, currentNode, nextNodeCost));
				}
				else
				{
					var nextNodePriceScaled = nextNodeCost.Price;
					if (node.ExtraCost != null && node.ExtraCost.Count > 0)
					{
						nextNodePriceScaled += node.ExtraCost.Sum(x => x * nextNodeCost.Price);
					}

					if ((routePriorityType == RoutePriorityType.Cheapest && node.ScaledPrice > nextNodePriceScaled)
					    || (routePriorityType == RoutePriorityType.Fastest &&
					        node.ConnectionData.Duration > nextNodeCost.Duration))
					{
						node.ConnectionData = nextNodeCost;
						node.CameFrom = currentNode;
						node.ScaledPrice = nextNodePriceScaled;
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
			_openNodes = new List<GraphNode> {_startNode};
			_route = new List<GraphNode>();

			while (_openNodes.Count > 0)
			{
				var currentNode = routePriorityType == RoutePriorityType.Cheapest
					? _openNodes.OrderBy(n => n.ConnectionData.Price).First()
					: _openNodes.OrderBy(n => n.ConnectionData.Duration).First();

				if (currentNode.City.Name.Equals(_cityTo.Name))
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