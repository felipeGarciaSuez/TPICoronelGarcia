using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            _adminService.CreateProduct(product);
            return Ok();
        }

        [HttpPut("ModifyProduct")]
        public IActionResult ModifyProduct(Product product)
        {
            _adminService.ModifyProduct(product);
            return Ok();
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            _adminService.DeleteProduct(productId);
            return Ok();
        }

        [HttpGet("GetUserById/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _adminService.GetUserById(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _adminService.GetAllUsers();
            return Ok(users);
        }
    }
}
