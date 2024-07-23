using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto orderDto);
        void UpdateOrder(OrderDto orderDto);
        void DeleteOrder(int orderId);
        OrderDto GetOrderById(int orderId);
        IEnumerable<OrderDto> GetAllOrders();
        void ChangeOrderState(int orderId, string newState);
        void PayOrder(int orderId);
        void AddProductToOrder(int orderId, int productId);
        void DeleteProductFromOrder(int orderId, int productId);
    }
}