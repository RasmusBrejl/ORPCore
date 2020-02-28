using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ORPCore.Business;
using ORPCore.Business.Repositories;
using ORPCore.Business.Services;
using ORPCore.Models;
using ORPCore.Models.Enums;



namespace ORPCore.Controllers
{
    [ApiController]
    [Route("RequestRoute")]
    public class RequestRouteController : Controller
    {
        private readonly RouteService _routeService;



        public RequestRouteController()
        {
            _routeService = new RouteService(new ConnectionRepository(), new CityRepository());
        }



        [HttpGet]
        [Route("CalculateRoute")]
        public List<Order> CalculateRoute(string city1, string city2, [FromBody] Parcel parcel)
        {
            var cityOne = _routeService.GetCity(city1);
            var cityTwo = _routeService.GetCity(city2);
            return new RoutePlannerGraph(cityOne, cityTwo, _routeService, parcel).ComputeRoutes();
        }



        // Respond request
        [HttpGet]
        public ConnectionData GetConnectionData([FromBody] RequestRouteObject request)
        {
            if (request is null)
            {
                return null;
            }



            var connection = _routeService.GetConnection(request.city_from, request.city_to);
            if (connection == null)
            {
                return new ConnectionData
                {
                    Duration = 10,
                    Price = 20
                };
            }



            if (!connection.ConnectionType.Equals(ConnectionType.Plane))
            {
                return null;
            }



            var parcelTypes = new List<ParcelType>();
            if (request.animals) parcelTypes.Add(ParcelType.LiveAnimals);
            if (request.weapons) parcelTypes.Add(ParcelType.Weapons);
            if (request.fragile) parcelTypes.Add(ParcelType.CautiousParcels);
            if (request.recommended_delivery) parcelTypes.Add(ParcelType.Recommended);
            if (request.cold) parcelTypes.Add(ParcelType.RefrigeratedGoods);



            var parcel = new Parcel()
            {
                Width = request.width,
                Height = request.height,
                Length = request.length,
                Weight = request.weight,
                ParcelTypes = parcelTypes.Select(x => (int)x).ToList()
            };



            var connectionData = _routeService.GetConnectionData(parcel, out string errorMessage);
            if (connectionData == null)
            {
                throw new HttpRequestException(errorMessage);
            }



            return connectionData;
        }
    }
}