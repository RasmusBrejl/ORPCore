using ORP.Business.Extensions;
using ORP.Business.Repositories;
using ORP.Models;
using ORP.Models.Enums;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ORP.Business.Services
{
	public class RouteService
	{
		private readonly ConnectionRepository _connectionRepository;
		private readonly CityRepository _cityRepository;
		private static HttpClient client = new HttpClient();

		public RouteService(ConnectionRepository connectionRepository, CityRepository cityRepository)
		{
			_connectionRepository = connectionRepository;
			_cityRepository = cityRepository;
		}

		public Connection GetConnection(string cityFromName, string cityToName)
		{
			var cityFrom = _cityRepository.GetCity(cityFromName);
			var cityTo = _cityRepository.GetCity(cityToName);

			return _connectionRepository.GetConnection(cityFrom, cityTo);
		}

		public ConnectionData GetConnectionData(Parcel parcel, out string errorMessage)
		{
			if (parcel.ParcelTypes != null)
			{
				var parcelTypes = parcel.ParcelTypes;
				if (parcelTypes.Any(Settings.InvalidParcelTypes.Contains))
				{
					errorMessage = Settings.PackageInvalidTypeMessage;
					return null;
				}
			}

			var parcelSizeType = parcel.GetSizeType();

			if (parcelSizeType == ParcelSizeType.Invalid)
			{
				errorMessage = Settings.PackageInvalidSizeMessage;
				return null;
			}

			var parcelWeightType = parcel.GetWeightType();

			if (parcelWeightType == ParcelWeightType.Invalid)
			{
				errorMessage = Settings.PackageInvalidWeightMessage;
				return null;
			}

			float basePrice;

			if (parcelSizeType == ParcelSizeType.Small)
			{
				if (parcelWeightType == ParcelWeightType.Light)
					basePrice = Settings.PriceSmallLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					basePrice = Settings.PriceSmallMedium;
				else
					basePrice = Settings.PriceSmallHeavy;
			}
			else if (parcelSizeType == ParcelSizeType.Medium)
			{
				if (parcelWeightType == ParcelWeightType.Light)
					basePrice = Settings.PriceMediumLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					basePrice = Settings.PriceMediumMedium;
				else
					basePrice = Settings.PriceMediumHeavy;
			}
			else
			{
				if (parcelWeightType == ParcelWeightType.Light)
					basePrice = Settings.PriceLargeLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					basePrice = Settings.PriceLargeMedium;
				else
					basePrice = Settings.PriceLargeHeavy;
			}

			var totalPrice = basePrice;
			if (parcel.ParcelTypes != null)
			{
				totalPrice += parcel.ParcelTypes.Sum(parcelCategory => basePrice * parcelCategory.ToPriceModifier());
			}

			errorMessage = string.Empty;
			return new ConnectionData()
			{
				Duration = Settings.FlightDuration,
				Price = totalPrice
			};
		}

		// Sent request
		public async Task<ConnectionData> GetConnectionDataFromRouteRequest(string url) 
		{
			ConnectionData connectionData = null;
			client.BaseAddress = new Uri("base");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.GetAsync(url);
			//if (response.IsSuccessStatusCode)
			//{
			//	connectionData = await response.Content.ReadAsAsync<ConnectionData>();
			//}
			return connectionData;
		}
	}
}