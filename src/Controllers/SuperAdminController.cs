using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _superAdminService;

        public SuperAdminController(ISuperAdminService superAdminService)
        {
            _superAdminService = superAdminService;
        }

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin(Admin admin)
        {
            _superAdminService.CreateAdmin(admin);
            return Ok();
        }

        [HttpPut("ModifyUser")]
        public IActionResult ModifyUser(User user)
        {
            _superAdminService.ModifyUser(user);
            return Ok();
        }

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            _superAdminService.DeleteUser(userId);
            return Ok();
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            _superAdminService.CreateProduct(product);
            return Ok();
        }

        [HttpPut("ModifyProduct")]
        public IActionResult ModifyProduct(Product product)
        {
            _superAdminService.ModifyProduct(product);
            return Ok();
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            _superAdminService.DeleteProduct(productId);
            return Ok();
        }

        [HttpGet("GetUserById/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _superAdminService.GetUserById(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _superAdminService.GetAllUsers();
            return Ok(users);
        }
    }
}