using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AplicattionContext _context;

        public AdminRepository(AplicattionContext context)
        {
            _context = context;
        }

        // Métodos para la gestión de productos
        public async Task AddProductAsync(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task ModifyProductAsync(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Set<Product>().FindAsync(productId);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        // Métodos para la gestión de usuarios
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Set<User>().FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }
    }
}
