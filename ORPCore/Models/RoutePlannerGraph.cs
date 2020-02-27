using System.Collections.Generic;

namespace ORP.Models
{
	public class RoutePlannerGraph
	{
		private readonly City _cityFrom;
		private readonly City _cityTo;

		public RoutePlannerGraph(City cityFrom, City cityTo)
		{
			_cityFrom = cityFrom;
			_cityTo = cityTo;
		}

		public List<Order> ComputeRoutes()
		{
			// TODO: Add functionality and return fastest + cheapest route
			var orders = new List<Order>();
			var fastestRoute = ComputeFastestRoute();
			var cheapestRoute = ComputeCheapestRoute();
			orders.Add(fastestRoute);

			if (fastestRoute != cheapestRoute)
				orders.Add(cheapestRoute);

			return orders;
		}

		private Order ComputeFastestRoute()
		{
			return new  Order();
		}

		private Order ComputeCheapestRoute()
		{
			return new Order();
		}
	}
}