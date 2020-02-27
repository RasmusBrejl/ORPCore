using System;
using ORP.Business.Services;
using ORP.Models;
using ORP.Models.Enums;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORP.Business.Repositories;

namespace ORP.Controllers
{
    public class RequestRouteController : Controller
    {
        private readonly RouteService _routeService;

        public RequestRouteController()
        {
            _routeService = new RouteService(new ConnectionRepository(), new CityRepository());
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
                    Date = DateTime.UtcNow.ToString(),
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