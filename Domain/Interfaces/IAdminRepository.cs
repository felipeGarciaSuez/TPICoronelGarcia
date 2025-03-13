using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdminRepository
    {
        Task AddProductAsync(Product product);
        Task ModifyProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
