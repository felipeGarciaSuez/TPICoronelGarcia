using Application.DTO;
using Application.IServices;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Brand = productDto.Brand,
                Stock = productDto.Stock,
                Price = productDto.Price,
                State = productDto.State
            };
            await _productRepository.AddAsync(product);  // Usamos await para métodos asincrónicos
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);  // Usamos await para obtener el producto
            if (product == null) return;

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Brand = productDto.Brand;
            product.Stock = productDto.Stock;
            product.Price = productDto.Price;
            product.State = productDto.State;

            await _productRepository.UpdateAsync(product);  // Usamos await para actualizar el producto
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);  // Usamos await para obtener el producto
            if (product != null)
            {
                await _productRepository.DeleteAsync(productId);  // Usamos await para eliminar el producto
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);  // Usamos await para obtener el producto
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Stock = product.Stock,
                Price = product.Price,
                State = product.State
            };
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();  // Usamos await para obtener todos los productos
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Brand = p.Brand,
                Stock = p.Stock,
                Price = p.Price,
                State = p.State
            }).ToList();
        }
    }
}
