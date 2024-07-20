using Application.DTO;
using Application.IServices;
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
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
        }

        public void CreateProduct(ProductDto productDto)
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
            _products.Add(product);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _products.SingleOrDefault(p => p.Id == productDto.Id);
            if (product == null) return;

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Brand = productDto.Brand;
            product.Stock = productDto.Stock;
            product.Price = productDto.Price;
            product.State = productDto.State;
        }

        public void DeleteProduct(int productId)
        {
            var product = _products.SingleOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public ProductDto GetProductById(int productId)
        {
            var product = _products.SingleOrDefault(p => p.Id == productId);
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

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _products.Select(p => new ProductDto
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