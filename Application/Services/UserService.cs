using Application.IServices;
using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            return user != null ? new UserDto { Id = user.Id, Name = user.Name, Email = user.Email } : null;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(user => new UserDto { Id = user.Id, Name = user.Name, Email = user.Email });
        }

        public async Task RegisterUser(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password // Hash en un futuro
            };

            await _userRepository.AddUserAsync(user);
        }
    }
}