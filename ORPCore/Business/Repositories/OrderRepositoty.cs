using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORP.Models;

namespace ORP.Business.Repositories
{
    public class OrderRepositoty
    {
        private string connectionString =
            "Data Source=dbs-oapl.database.windows.net;Initial Catalog=db-prod;User ID=dbs-oapl;Password=oceanicFlyAway16";

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