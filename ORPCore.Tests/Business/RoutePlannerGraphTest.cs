using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ORP.Business.Repositories;
using ORP.Models;
using ORP.Models.Enums;
using ORPCore.Business;
using ORPCore.Business.Repositories;
using ORPCore.Business.Services;
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
		public void ComputeRoutes_GivenBoatAndPlaneConnection_ReturnsTwoRoutes()
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
		}
	}
}