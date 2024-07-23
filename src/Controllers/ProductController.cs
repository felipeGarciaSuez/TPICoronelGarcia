using Application.IServices;
using Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            _productService.CreateProduct(productDto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult UpdateProduct([FromBody] ProductDto productDto)
        {
            _productService.UpdateProduct(productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
    }
}
