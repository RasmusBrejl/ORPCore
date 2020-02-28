using System;
using System.Collections.Generic;
using ORP.Business.Services;
using ORP.Models;
using ORP.Models.Enums;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORP.Business.Repositories;
using ORPCore.Business;
using ORPCore.Business.Repositories;
using ORPCore.Business.Services;

namespace ORP.Controllers
{
    public class RequestRouteController : Controller
    {
        private readonly RouteService _routeService;

        public RequestRouteController()
        {
            _routeService = new RouteService(new ConnectionRepository(), new CityRepository());
        }

        [HttpGet]
        public List<Order> CalculateRoute(string city1, string city2, [FromBody] Parcel parcel)
        {
            var cityOne = _routeService.GetCity(city1);
            var cityTwo = _routeService.GetCity(city2);
            return new RoutePlannerGraph(cityOne, cityTwo, _routeService, parcel).ComputeRoutes();
        }

        [HttpGet]
        public ConnectionData Index()
        {
            return new ConnectionData
            {
                Price = 10,
                Duration =  40
            };
        }

        // Respond request
        public ConnectionData GetConnectionData([FromBody] RequestRouteObject request)
        {

            if (request is null)
            {
                return null;
            }

            Connection RouteConnection = _routeService.GetConnection(request.city_from, request.city_to);
            if (RouteConnection == null)
            {
                return new ConnectionData
                {
                    Duration = 10,
                    Price = 20
                };
            }

            if (RouteConnection.ConnectionType.Equals(ConnectionType.Plane))
            {
                return _routeService.GetConnectionData(new Parcel
                {
                    Weight = request.weight,
                    Width = request.width,
                    Height = request.height,
                    Length = request.length

                }, out var msg);
            }

            return null;
        }
    }
}