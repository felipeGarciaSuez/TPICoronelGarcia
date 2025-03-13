using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        Task RegisterUser(UserDto userDto);
        Task<UserDto> Login(string email, string password);
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}