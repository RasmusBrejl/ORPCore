using ORP.Business.Repositories;
using ORP.Models;

namespace ORP.Business.Services
{
    public class OrderService
    {
        private readonly TestRepository _orderRepository;

        public OrderService(TestRepository orderRepository)
        {
            // TODO : Replace TestRepository with OrderRepository
            _orderRepository = orderRepository;
        }

        public Order[] GetAllOrders(User user) 
        {
            // TODO add getter
            return new Order[1];
        }

        public bool AddOrder(Order order)
        {
            // TODO add setter
            return true;
        }

        public Order GetOrder(int OrderId)
        {
            // TODO add getter
            return new Order();
        }
    }
}