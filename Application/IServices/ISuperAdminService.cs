using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISuperAdminService : IAdminService
    {
        void CreateAdmin(Admin admin);
        void ModifyUser(User user);
        void DeleteUser(int userId);
    }
}