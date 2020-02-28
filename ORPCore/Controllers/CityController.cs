using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORP.Business.Repositories;
using ORPCore.Business.Repositories;
using ORPCore.Business.Services;
using ORPCore.Models;

namespace ORPCore.Controllers
{
    public class CityController : Controller
    {
        private readonly RouteService _routeService;
        public CityController()
        {
            _routeService = new RouteService(new ConnectionRepository(), new CityRepository());
        }

        public List<City> GetAllCities()
        {
            return _routeService.GetAllCities();
        }
    }
}
