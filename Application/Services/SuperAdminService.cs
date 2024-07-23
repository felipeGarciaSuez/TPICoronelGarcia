﻿using Application.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SuperAdminService : AdminService, ISuperAdminService
    {
        private readonly List<Admin> _admins;

        public SuperAdminService()
        {
            _admins = new List<Admin>();
        }

        public void CreateAdmin(Admin admin)
        {
            _admins.Add(admin);
        }

        public void ModifyUser(User user)
        {
            var existingUser = _users.SingleOrDefault(u => u.Id == user.Id);
            if (existingUser == null) return;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
        }

        public new void DeleteUser(int userId)
        {
            var user = _users.SingleOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}