using Application.DTO;
using Application.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;
        private readonly List<Customer> _customers;
        private readonly List<Product> _products;

        public OrderService()
        {
            _orders = new List<Order>();
            _customers = new List<Customer>();
            _products = new List<Product>();
        }

        public void CreateOrder(OrderDto orderDto)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == orderDto.CustomerId);
            if (customer == null) return;

            var order = new Order
            {
                Id = orderDto.Id,
                Customer = customer,
                DateOrder = orderDto.DateOrder,
                State = orderDto.State,
                Total = orderDto.Total
            };

            foreach (var productId in orderDto.ProductIds)
            {
                var product = _products.SingleOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    order.AddProduct(product);
                }
            }

            _orders.Add(order);
            customer.Orders.Add(order);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var order = _orders.SingleOrDefault(o => o.Id == orderDto.Id);
            if (order == null) return;

            order.DateOrder = orderDto.DateOrder;
            order.State = orderDto.State;
            order.Total = orderDto.Total;

            order.Products.Clear();
            foreach (var productId in orderDto.ProductIds)
            {
                var product = _products.SingleOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    order.AddProduct(product);
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orders.SingleOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                _orders.Remove(order);
                order.Customer.Orders.Remove(order);
            }
        }

        public OrderDto GetOrderById(int orderId)
        {
            var order = _orders.SingleOrDefault(o => o.Id == orderId);
            if (order == null) return null;

            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.Customer.Id,
                ProductIds = order.Products.Select(p => p.Id).ToList(),
                DateOrder = order.DateOrder,
                State = order.State,
                Total = order.Total
            };
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            return _orders.Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.Customer.Id,
                ProductIds = o.Products.Select(p => p.Id).ToList(),
                DateOrder = o.DateOrder,
                State = o.State,
                Total = o.Total
            }).ToList();
        }

        public void ChangeOrderState(int orderId, string newState)
        {
            var order = _orders.SingleOrDefault(o => o.Id == orderId);
            if (order == null) return;

            order.ChangeState(newState);
        }

        public void PayOrder(int orderId)
        {
            var order = _orders.SingleOrDefault(o => o.Id == orderId);
            if (order == null) return;

            order.PayOrder();
        }

        public void AddProductToOrder(int orderId, int productId)
        {
            var order = _orders.SingleOrDefault(o => o.Id == orderId);
            var product = _products.SingleOrDefault(p => p.Id == productId);
            if (order == null || product == null) return;

            order.AddProduct(product);
        }

        public void DeleteProductFromOrder(int orderId, int productId)
        {
            var order = _orders.SingleOrDefault(o => o.Id == orderId);
            var product = _products.SingleOrDefault(p => p.Id == productId);
            if (order == null || product == null) return;

            order.DeleteProduct(product);
        }
    }
}