using Application.DTO;
using Application.IServices;
using Domain.Models;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public AdminService(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            return product;
        }

        public async Task ModifyProduct(Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Brand = product.Brand;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.State = product.State;

                await _productRepository.UpdateAsync(existingProduct);
            }
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product != null)
            {
                await _productRepository.DeleteAsync(productId);
            }
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }
    }
}
