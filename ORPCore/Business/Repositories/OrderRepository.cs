using System.Collections.Generic;
using System.Linq;
using ORP.Models;
using ORP.Models.Context;

namespace ORP.Business.Repositories
{
    public class OrderRepository
    {
        public List<Order> GetAllOrders(User user)
        {
            using (var context = new OrpContext())
            {
                return context.Users.FirstOrDefault(x => x.UserId == user.UserId)?.Orders;
            }
        }

        public Order GetOrder(int orderId)
        {
            using (var context = new OrpContext())
            {
                return context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            }
        }

        public bool AddOrder(Order order, User user)
        {
            using (var context = new OrpContext())
            {
                try
                {
                    context.Users.FirstOrDefault(x => x.UserId == user.UserId)?.Orders.Add(order);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}