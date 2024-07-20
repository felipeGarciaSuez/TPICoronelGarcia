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
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();
        }

        public void CreateCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Email = customerDto.Email,
                Password = customerDto.Password,
                Orders = customerDto.Orders.Select(o => new Order
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    DateOrder = o.DateOrder,
                    State = o.State,
                    Total = o.Total
                }).ToList()
            };
            _customers.Add(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == customerDto.Id);
            if (customer == null) return;

            customer.Name = customerDto.Name;
            customer.Email = customerDto.Email;
            customer.Password = customerDto.Password;
            customer.Orders = customerDto.Orders.Select(o => new Order
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                DateOrder = o.DateOrder,
                State = o.State,
                Total = o.Total
            }).ToList();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == customerId);
            if (customer == null) return null;

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Password = customer.Password,
                Orders = customer.Orders.Select(o => new OrderDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    DateOrder = o.DateOrder,
                    State = o.State,
                    Total = o.Total
                }).ToList()
            };
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            return _customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Password = c.Password,
                Orders = c.Orders.Select(o => new OrderDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    DateOrder = o.DateOrder,
                    State = o.State,
                    Total = o.Total
                }).ToList()
            }).ToList();
        }

        public void CreateOrder(int customerId, OrderDto orderDto)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == customerId);
            if (customer == null) return;

            var order = new Order
            {
                Id = orderDto.Id,
                Customer = customer,
                DateOrder = orderDto.DateOrder,
                State = orderDto.State,
                Total = orderDto.Total
            };

            customer.CreateOrder(order);
        }

        public void DeleteOrder(int customerId, int orderId)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == customerId);
            if (customer == null) return;

            var order = customer.Orders.SingleOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                customer.DeleteOrder(order);
            }
        }
    }
}