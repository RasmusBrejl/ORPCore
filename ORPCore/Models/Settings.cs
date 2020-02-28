using ORPCore.Models.Enums;

namespace ORPCore.Models
{
    public static class Settings
    {
        public const int SmallWidth = 25;
        public const int SmallHeight = 25;
        public const int SmallLength = 25;

        public const int MediumWidth = 40;
        public const int MediumHeight = 40;
        public const int MediumLength = 40;

        public const int LargeWidth = 200;
        public const int LargeHeight = 200;
        public const int LargeLength = 200;

        public const int LightWeight = 1;
        public const int MediumWeight = 5;
        public const int HeavyWeight = 20;

        public const float PriceSmallLight = 40.0f;
        public const float PriceSmallMedium = 60.0f;
        public const float PriceSmallHeavy = 80.0f;

        public const float PriceMediumLight = 48.0f;
        public const float PriceMediumMedium = 68.0f;
        public const float PriceMediumHeavy = 88.0f;

        public const float PriceLargeLight = 80.0f;
        public const float PriceLargeMedium = 100.0f;
        public const float PriceLargeHeavy = 120.0f;

        public const float PriceModifierWeapons = 1.00f;
        public const float PriceModifierCautious = 0.75f;
        public const float PriceModifierRefrigerated = 0.10f;

        public static readonly ParcelType[] InvalidParcelTypes = {
            ParcelType.Recommended, ParcelType.LiveAnimals
        };

        public const float FlightDuration = 8.0f;

        public const string PackageInvalidWeightMessage = "Package weight not supported";
        public const string PackageInvalidSizeMessage = "Package size not supported";
        public const string PackageInvalidTypeMessage = "Package type not supported";
        public const string InvalidConnectionTypeMessage = "The connection is not supported";

        public const string EndpointTelstar = "https://wa-tlpl.azurewebsites.net/RequestRoute";
        public const string EndpointEastIndia = "https://wa-eitpl.azurewebsites.net/RequestRoute";
    }
}