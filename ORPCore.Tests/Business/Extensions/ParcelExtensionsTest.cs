using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORPCore.Business.Extensions;
using ORPCore.Models;
using ORPCore.Models.Enums;

namespace ORPCore.Tests.Business.Extensions
{
	[TestClass]
	public class ParcelExtensionsTest
	{
		[TestMethod]
		public void GetWeightType_GivenNegativeWeight_ReturnsInvalidParcelWeightType()
		{
			// Arrange
			var weight = -1f;
			var parcel = new Parcel()
			{
				Weight = weight
			};

			// Act
			var actual = parcel.GetWeightType();

			// Assert
			Assert.AreEqual(ParcelWeightType.Invalid, actual);
		}

		[TestMethod]
		public void GetWeightType_GivenTooHeavyParcel_ReturnsInvalidParcelWeightType()
		{
			// Arrange
			var weight = Settings.HeavyWeight + 1;
			var parcel = new Parcel()
			{
				Weight = weight
			};

			// Act
			var actual = parcel.GetWeightType();

			// Assert
			Assert.AreEqual(ParcelWeightType.Invalid, actual);
		}

		[TestMethod]
		public void GetWeightType_GivenHeavyParcel_ReturnsHeavyParcelWeightType()
		{
			// Arrange
			var weight = (Settings.MediumWeight + Settings.HeavyWeight) / 2;
			var parcel = new Parcel()
			{
				Weight = weight
			};

			// Act
			var actual = parcel.GetWeightType();

			// Assert
			Assert.AreEqual(ParcelWeightType.Heavy, actual);
		}

		[TestMethod]
		public void GetWeightType_GivenMediumParcel_ReturnsMediumParcelWeightType()
		{
			// Arrange
			var weight = (Settings.LightWeight + Settings.MediumWeight) / 2;
			var parcel = new Parcel()
			{
				Weight = weight
			};

			// Act
			var actual = parcel.GetWeightType();

			// Assert
			Assert.AreEqual(ParcelWeightType.Medium, actual);
		}

		[TestMethod]
		public void GetWeightType_GivenLightParcel_ReturnsLightParcelWeightType()
		{
			// Arrange
			var weight = Settings.LightWeight / 2;
			var parcel = new Parcel()
			{
				Weight = weight
			};

			// Act
			var actual = parcel.GetWeightType();

			// Assert
			Assert.AreEqual(ParcelWeightType.Light, actual);
		}

		[TestMethod]
		public void GetSizeType_GivenNegativeSizes_ReturnsInvalidParcelSizeType()
		{
			// Arrange
			var width = -1f;
			var height = -1f;
			var length = -1f;

			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length
			};

			// Act
			var actual = parcel.GetSizeType();

			// Assert
			Assert.AreEqual(ParcelSizeType.Invalid, actual);
		}

		[TestMethod]
		public void GetSizeType_GivenTooLargeParcel_ReturnsInvalidParcelSizeType()
		{
			// Arrange
			var width = Settings.LargeWidth + 1;
			var height = Settings.LargeHeight + 1;
			var length = Settings.LargeLength + 1;

			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length
			};

			// Act
			var actual = parcel.GetSizeType();

			// Assert
			Assert.AreEqual(ParcelSizeType.Invalid, actual);
		}

		[TestMethod]
		public void GetSizeType_GivenLargeParcel_ReturnsLargeParcelSizeType()
		{
			// Arrange
			var width = (Settings.MediumWidth + Settings.LargeWidth) / 2;
			var height = (Settings.MediumHeight + Settings.LargeHeight) / 2;
			var length = (Settings.MediumLength + Settings.LargeLength) / 2;

			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length
			};

			// Act
			var actual = parcel.GetSizeType();

			// Assert
			Assert.AreEqual(ParcelSizeType.Large, actual);
		}

		[TestMethod]
		public void GetSizeType_GivenMediumSizeParcel_ReturnsMediumParcelSizeType()
		{
			// Arrange
			var width = (Settings.SmallWidth + Settings.MediumWidth) / 2;
			var height = (Settings.SmallHeight + Settings.MediumHeight) / 2;
			var length = (Settings.SmallLength + Settings.MediumLength) / 2;

			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length
			};

			// Act
			var actual = parcel.GetSizeType();

			// Assert
			Assert.AreEqual(ParcelSizeType.Medium, actual);
		}

		[TestMethod]
		public void GetSizeType_GivenSmallSizeParcel_ReturnsSmallParcelSizeType()
		{
			// Arrange
			var width = Settings.SmallWidth / 2;
			var height = Settings.SmallHeight / 2;
			var length = Settings.SmallLength / 2;

			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length
			};

			// Act
			var actual = parcel.GetSizeType();

			// Assert
			Assert.AreEqual(ParcelSizeType.Small, actual);
		}
	}
}