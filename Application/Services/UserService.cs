using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public void RegisterUser(User user)
        {
            _users.Add(user);
        }

        public User Login(string email, string password)
        {
            return _users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }
    }
}