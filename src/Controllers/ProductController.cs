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

        // Este endpoint requiere que el usuario esté autenticado y tenga el rol de 'Admin' o 'SuperAdmin'
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            _productService.CreateProduct(productDto);
            return Ok();
        }

        // Este endpoint requiere que el usuario esté autenticado y tenga el rol de 'Admin' o 'SuperAdmin'
        [HttpPut]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult UpdateProduct([FromBody] ProductDto productDto)
        {
            _productService.UpdateProduct(productDto);
            return Ok();
        }

        // Este endpoint requiere que el usuario esté autenticado y tenga el rol de 'Admin' o 'SuperAdmin'
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }

        // Este endpoint puede ser accedido por cualquier usuario autenticado
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        // Este endpoint puede ser accedido por cualquier usuario autenticado
        [HttpGet]
        [Authorize]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
    }
}
