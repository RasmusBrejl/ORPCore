using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORPCore.Business.Repositories;
using ORPCore.Business.Services;
using System.Collections.Generic;
using ORPCore.Models;
using ORPCore.Models.Enums;

namespace ORPCore.Tests.Business.Services
{
	[TestClass]
	public class RouteServiceTest
	{
		[TestMethod]
		public void GetConnectionData_GivenParcelOfInvalidType_ReturnsNull()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var parcel = new Parcel()
			{
				ParcelTypes = new List<int>()
				{
					(int)ParcelType.LiveAnimals
				}
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.IsNull(result);
			Assert.AreEqual(Settings.PackageInvalidTypeMessage, errorMessage);
		}

		[TestMethod]
		public void GetConnectionData_GivenSmallLightParcel_ReturnsPriceSmallLight()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceSmallLight, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenSmallMediumParcel_ReturnsPriceSmallMedium()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.MediumWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceSmallMedium, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenSmallHeavyParcel_ReturnsPriceSmallHeavy()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.HeavyWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceSmallHeavy, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenMediumLightParcel_ReturnsPriceMediumLight()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.MediumWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceMediumLight, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenMediumMediumParcel_ReturnsPriceMediumMedium()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.MediumWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.MediumWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceMediumMedium, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenMediumHeavyParcel_ReturnsPriceMediumHeavy()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.MediumWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.HeavyWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceMediumHeavy, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenLargeLightParcel_ReturnsPriceLargeLight()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.LargeWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceLargeLight, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenLargeMediumParcel_ReturnsPriceLargeMedium()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.LargeWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.MediumWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceLargeMedium, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenLargeHeavyParcel_ReturnsPriceLargeHeavy()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.LargeWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.HeavyWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceLargeHeavy, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_ParcelWithCategoryModifier_ReturnsModifiedPrice()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());

			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight,
				ParcelTypes = new List<int>()
				{
					(int)ParcelType.Weapons
				}
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);
			var totalModifier = 1 + Settings.PriceModifierWeapons;

			// Assert
			Assert.AreEqual(Settings.PriceSmallLight * totalModifier, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}
	}
}