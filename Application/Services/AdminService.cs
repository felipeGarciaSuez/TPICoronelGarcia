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
    public class AdminService : IAdminService
    {
        protected readonly List<Product> _products;
        protected readonly List<User> _users;

        public AdminService()
        {
            _products = new List<Product>();
            _users = new List<User>();
        }

        public void CreateProduct(Product product)
        {
            _products.Add(product);
        }

        public void ModifyProduct(Product product)
        {
            var existingProduct = _products.SingleOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Brand = product.Brand;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.State = product.State;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = _products.SingleOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public UserDto GetUserById(int userId)
        {
            var user = _users.SingleOrDefault(u => u.Id == userId);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password
            }).ToList();
        }
    }
}