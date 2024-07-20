using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        void RegisterUser(UserDto userDto);
        UserDto Login(string email, string password);
        IEnumerable<UserDto> GetAllUsers();
    }
}
