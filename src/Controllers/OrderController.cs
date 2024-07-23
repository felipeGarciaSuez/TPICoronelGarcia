using Application.DTO;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            _orderService.CreateOrder(orderDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] OrderDto orderDto)
        {
            _orderService.UpdateOrder(orderDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPatch("{id}/changeState")]
        public IActionResult ChangeOrderState(int id, [FromBody] string newState)
        {
            _orderService.ChangeOrderState(id, newState);
            return Ok();
        }

        [HttpPatch("{id}/pay")]
        public IActionResult PayOrder(int id)
        {
            _orderService.PayOrder(id);
            return Ok();
        }

        [HttpPost("{orderId}/products/{productId}")]
        public IActionResult AddProductToOrder(int orderId, int productId)
        {
            _orderService.AddProductToOrder(orderId, productId);
            return Ok();
        }

        [HttpDelete("{orderId}/products/{productId}")]
        public IActionResult DeleteProductFromOrder(int orderId, int productId)
        {
            _orderService.DeleteProductFromOrder(orderId, productId);
            return Ok();
        }
    }
}