using ORPCore.Models;
using ORPCore.Models.Enums;

namespace ORPCore.Business.Extensions
{
	public static class ParcelExtensions
	{
		public static ParcelWeightType GetWeightType(this Parcel parcel)
		{
			if (parcel.Weight < 0) return ParcelWeightType.Invalid;

			if (parcel.Weight <= Settings.LightWeight) return ParcelWeightType.Light;

			if (parcel.Weight <= Settings.MediumWeight) return ParcelWeightType.Medium;

			if (parcel.Weight <= Settings.HeavyWeight) return ParcelWeightType.Heavy;

			return ParcelWeightType.Invalid;
		}

		public static ParcelSizeType GetSizeType(this Parcel parcel)
		{
			if (parcel.Width < 0 || parcel.Height < 0 || parcel.Length < 0) return ParcelSizeType.Invalid;

			if (parcel.Width <= Settings.SmallWidth && parcel.Height <= Settings.SmallHeight &&
			    parcel.Length <= Settings.SmallLength)
				return ParcelSizeType.Small;

			if (parcel.Width <= Settings.MediumWidth && parcel.Height <= Settings.MediumHeight &&
			    parcel.Length <= Settings.MediumLength)
				return ParcelSizeType.Medium;

			if (parcel.Width <= Settings.LargeWidth && parcel.Height <= Settings.LargeWidth &&
			    parcel.Length <= Settings.LargeLength)
				return ParcelSizeType.Large;

			return ParcelSizeType.Invalid;
		}
	}
}