using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using ORP.Models;

namespace ORP.Controllers
{
    public class OrderController : Controller
    {
        public Order[] GetAllOrders(User user)
        {
            //Dummy
            Order[] orders = null;
            return orders;

        }

        public bool AddOrder(Order order)
        {
            //Dummy
            return true;
        }

        public Order GetOrder(int OrderId)
        {
            //Dummy
            Order order = null;
            return order;
        }
    }
}