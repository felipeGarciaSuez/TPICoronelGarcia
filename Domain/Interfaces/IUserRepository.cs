using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}