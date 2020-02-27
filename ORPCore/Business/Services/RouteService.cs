using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ORP.Business.Extensions;
using ORP.Business.Repositories;
using ORP.Models;
using ORP.Models.Enums;
using ORPCore.Business.Repositories;
using ORPCore.Models;

namespace ORPCore.Business.Services
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
			var cityFrom = GetCity(cityFromName);
			var cityTo = GetCity(cityToName);

			return _connectionRepository.GetConnection(cityFrom, cityTo);
		}

		public City GetCity(string cityName)
		{
			return _cityRepository.GetCity(cityName);
		}

		public ConnectionData GetConnectionData(Parcel parcel, out string errorMessage)
		{
			if (parcel.ParcelTypes != null)
			{
				var parcelTypes = parcel.ParcelTypes.Select(x=>(ParcelType)x);
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
				totalPrice += parcel.ParcelTypes.Sum(parcelCategory => basePrice * ((ParcelType) parcelCategory).ToPriceModifier());
			}

			errorMessage = string.Empty;
			return new ConnectionData()
			{
				Duration = Settings.FlightDuration,
				Price = totalPrice
			};
		}

		public List<Connection> GetConnectionsForCity(City city)
		{
			return _connectionRepository.GetConnections(city);
		}

		public ConnectionData GetConnectionDataBoat(Parcel parcel)
		{
			return new ConnectionData()
			{
				Duration = 20f,
				Price = 10f
			};
		}

		public ConnectionData GetConnectionDataCar(Parcel parcel)
		{
			return new ConnectionData()
			{
				Duration = 10f,
				Price = 20f
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