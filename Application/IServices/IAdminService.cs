using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAdminService
    {
        void CreateProduct(Product product);
        void ModifyProduct(Product product);
        void DeleteProduct(int productId);
        UserDto GetUserById(int userId);
        IEnumerable<UserDto> GetAllUsers();
    }
}