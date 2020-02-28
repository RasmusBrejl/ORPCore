using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using ORP.Buisness.Services;
using ORP.Business.Repositories;
using ORP.Business.Services;
using ORP.Models;

namespace ORP.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly UserService _userService;
        public OrderController()
        {
            _orderService = new OrderService(new OrderRepository());
            _userService = new UserService(new UserRepository());
        }
        [HttpGet]
        public List<Order> GetAllOrders(User user)
        {
            return _orderService.GetAllOrders(user);
        }

        [HttpPost]
        public bool AddOrder(int userId, [FromBody] Order order)
        {
            var user = _userService.GetUser(userId);
            return _orderService.AddOrder(order, user);
        }

        [HttpGet]
        public Order GetOrder(int orderId)
        {
            return _orderService.GetOrder(orderId);
        }
    }
}