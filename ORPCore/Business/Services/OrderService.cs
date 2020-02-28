using System.Collections.Generic;
using ORP.Business.Repositories;
using ORP.Models;

namespace ORP.Business.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders(User user)
        {
            return _orderRepository.GetAllOrders(user);
        }

        public bool AddOrder(Order order, User user)
        {
            return _orderRepository.AddOrder(order, user);
        }

        public Order GetOrder(int orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }
    }
}