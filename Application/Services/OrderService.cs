using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        public void CreateOrder(Order order)
        {
            _orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }

        public Order GetOrderById(int id)
        {
            return _orders.SingleOrDefault(o => o.Id == id);
        }
    }
}