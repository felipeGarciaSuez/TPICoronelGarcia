using Application.DTO;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAdminService
    {
        Task<Product> CreateProduct(Product product);
        Task ModifyProduct(Product product);
        Task DeleteProduct(int productId);
        Task<UserDto> GetUserById(int userId);
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}
