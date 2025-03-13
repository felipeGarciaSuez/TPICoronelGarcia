using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AplicattionContext _context;

        public ProductRepository(AplicattionContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Set<Product>().FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }
    }
}
