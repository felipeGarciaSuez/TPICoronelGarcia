using Application.DTO;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            _customerService.CreateCustomer(customerDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] CustomerDto customerDto)
        {
            _customerService.UpdateCustomer(customerDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPost("{customerId}/orders")]
        public IActionResult CreateOrder(int customerId, [FromBody] OrderDto orderDto)
        {
            _customerService.CreateOrder(customerId, orderDto);
            return Ok();
        }

        [HttpDelete("{customerId}/orders/{orderId}")]
        public IActionResult DeleteOrder(int customerId, int orderId)
        {
            _customerService.DeleteOrder(customerId, orderId);
            return Ok();
        }
    }
}
