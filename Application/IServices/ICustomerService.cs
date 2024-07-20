using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerDto customerDto);
        void UpdateCustomer(CustomerDto customerDto);
        void DeleteCustomer(int customerId);
        CustomerDto GetCustomerById(int customerId);
        IEnumerable<CustomerDto> GetAllCustomers();
        void CreateOrder(int customerId, OrderDto orderDto);
        void DeleteOrder(int customerId, int orderId);
    }
}
