//using Microsoft.AspNetCore.Mvc;
//using Application.Services;
//using Application.DTOs;

//namespace Web.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly AuthService _authService;

//        public AuthController(AuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpPost("login")]
//        public IActionResult Login(UserLoginDto userLogin)
//        {
//            var token = _authService.Authenticate(userLogin);
//            if (token == null)
//                return Unauthorized();

//            return Ok(new { Token = token });
//        }
//    }
//}