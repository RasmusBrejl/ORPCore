using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORPCore.Business;
using ORPCore.Business.Repositories;
using ORPCore.Business.Services;
using System.Collections.Generic;
using System.Linq;
using ORPCore.Models;

namespace ORPCore.Tests.Business
{
	[TestClass]
	public class RoutePlannerGraphTest
	{
		private static RouteService routeService;
		private static Parcel parcel;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			parcel = new Parcel()
			{
				Height = Settings.SmallHeight,
				Length = Settings.SmallLength,
				Width = Settings.SmallWidth,
				ParcelTypes = new List<int>()
				{
					0
				},
				Weight = Settings.LightWeight
			};

			routeService = new RouteService(new ConnectionRepository(), new CityRepository());
		}

		[TestMethod]
		public void ComputeRoutes_GivenKapstadenAndKapStMarie_ReturnsFlightAsFastestAndBoatAsSlowest()
		{
			// Arrange
			var cityRepository = new CityRepository();
			var cityStart = cityRepository.GetCity("kapstaden");
			var cityEnd = cityRepository.GetCity("kap_st_marie");

			var routePlannerGraph = new RoutePlannerGraph(cityStart, cityEnd, routeService, parcel);

			// Act
			var result = routePlannerGraph.ComputeRoutes();

			// Assert
			Assert.AreEqual(2, result.Count);
			Assert.AreEqual(80, result.First().Price);
			Assert.AreEqual(8, result.First().Duration);
			Assert.AreEqual(10, result.Last().Price);
			Assert.AreEqual(50, result.Last().Duration);
		}

		[TestMethod]
		public void ComputeRoutes_GivenKapstadenAndTunis_ReturnsFlightAsFastestAndBoatAsSlowest()
		{
			// Arrange
			var cityRepository = new CityRepository();
			var cityStart = cityRepository.GetCity("kapstaden");
			var cityEnd = cityRepository.GetCity("tunis");

			var routePlannerGraph = new RoutePlannerGraph(cityStart, cityEnd, routeService, parcel);

			// Act
			var result = routePlannerGraph.ComputeRoutes();

			// Assert
			Assert.AreEqual(2, result.Count);
			Assert.AreEqual(250, result.First().Price);
			Assert.AreEqual(49, result.First().Duration);
			Assert.AreEqual(50, result.Last().Price);
			Assert.AreEqual(250, result.Last().Duration);
		}

		[TestMethod]
		public void ComputeRoutes_GivenCairoAsCity_ReturnsEmptyOrderList()
		{
			// Arrange
			var cityRepository = new CityRepository();
			var cityStart = cityRepository.GetCity("cairo");
			var cityEnd = cityRepository.GetCity("tunis");

			var routePlannerGraph = new RoutePlannerGraph(cityStart, cityEnd, routeService, parcel);

			// Act
			var result = routePlannerGraph.ComputeRoutes();

			// Assert
			Assert.AreEqual(0, result.Count);
		}

		[TestMethod]
		public void ComputeRoutes_GivenTangeAndSierraLeone_ReturnsFlightAsFastestAndBoatAsSlowest()
		{
			// Arrange
			var cityRepository = new CityRepository();
			var cityStart = cityRepository.GetCity("tanger");
			var cityEnd = cityRepository.GetCity("sierra_leone");

			var routePlannerGraph = new RoutePlannerGraph(cityStart, cityEnd, routeService, parcel);

			// Act
			var result = routePlannerGraph.ComputeRoutes();

			// Assert
			Assert.AreEqual(2, result.Count);
			Assert.AreEqual(160, result.First().Price);
			Assert.AreEqual(16, result.First().Duration);
			Assert.AreEqual(30, result.Last().Price);
			Assert.AreEqual(150, result.Last().Duration);
		}
	}
}