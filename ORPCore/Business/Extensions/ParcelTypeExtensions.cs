using ORPCore.Models;
using ORPCore.Models.Enums;

namespace ORPCore.Business.Extensions
{
	public static class ParcelTypeExtensions
	{
		public static float ToPriceModifier(this ParcelType parcelType)
		{
			if (parcelType == ParcelType.CautiousParcels) return Settings.PriceModifierCautious;
			if (parcelType == ParcelType.RefrigeratedGoods) return Settings.PriceModifierRefrigerated;
			if (parcelType == ParcelType.Weapons) return Settings.PriceModifierWeapons;
			return 0f;
		}
	}
}