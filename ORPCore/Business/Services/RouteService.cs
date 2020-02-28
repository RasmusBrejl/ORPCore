using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ORPCore.Business.Extensions;
using ORPCore.Business.Repositories;
using ORPCore.Models;
using ORPCore.Models.Enums;

namespace ORPCore.Business.Services
{
	public class RouteService
	{
		private readonly ConnectionRepository _connectionRepository;
		private readonly CityRepository _cityRepository;

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

		public ConnectionData GetConnectionDataBoat(Parcel parcel, City cityFrom, City cityTo)
		{
			var routeObject = new RequestRouteObject()
			{
				city_from = cityFrom.Name,
				city_to = cityTo.Name,
				weight = parcel.Weight,
				width = parcel.Width,
				height = parcel.Height,
				length = parcel.Length,
				cold = parcel.ParcelTypes.Contains((int)ParcelType.RefrigeratedGoods),
				fragile = parcel.ParcelTypes.Contains((int)ParcelType.CautiousParcels),
				animals = parcel.ParcelTypes.Contains((int)ParcelType.LiveAnimals),
				weapons = parcel.ParcelTypes.Contains((int)ParcelType.Weapons),
				recommended_delivery = parcel.ParcelTypes.Contains((int)ParcelType.Recommended),
				date = DateTime.UtcNow
			};
			try
			{
				return GetConnectionDataFromRouteRequest(routeObject, ConnectionType.Boat).Result;
			}
			catch
			{
				return new ConnectionData()
				{
					Duration = 50,
					Price = 10
				};
			}
		}

		public ConnectionData GetConnectionDataCar(Parcel parcel, City cityFrom, City cityTo)
		{
			var routeObject = new RequestRouteObject()
			{
				city_from = cityFrom.Name,
				city_to = cityTo.Name,
				weight = parcel.Weight,
				width = parcel.Width,
				height = parcel.Height,
				length = parcel.Length,
				cold = parcel.ParcelTypes.Contains((int)ParcelType.RefrigeratedGoods),
				fragile = parcel.ParcelTypes.Contains((int)ParcelType.CautiousParcels),
				animals = parcel.ParcelTypes.Contains((int)ParcelType.LiveAnimals),
				weapons = parcel.ParcelTypes.Contains((int)ParcelType.Weapons),
				recommended_delivery = parcel.ParcelTypes.Contains((int)ParcelType.Recommended),
				date = DateTime.UtcNow
			};

			try
			{
				return GetConnectionDataFromRouteRequest(routeObject, ConnectionType.Car).Result;
			}
			catch
			{
				return new ConnectionData()
				{
					Duration = 50,
					Price = 10
				};
			}
		}

		// Sent request
		public async Task<ConnectionData> GetConnectionDataFromRouteRequest(RequestRouteObject routeObject, ConnectionType connectionType)
		{
			using var client = new HttpClient();
			var baseUrl = connectionType == ConnectionType.Boat
				? "http://wa-eitpl.azurewebsites.net/RequestRoute"
				: "http://wa-tlpl.azurewebsites.net/RequestRoute";

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(baseUrl),
				Content = new StringContent(JsonConvert.SerializeObject(routeObject), Encoding.UTF8)
			};

			var response = await client.SendAsync(request).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			return JsonConvert.DeserializeObject<ConnectionData>(responseBody);
		}
	}
}