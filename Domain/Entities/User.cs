using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool VerifyCredentials(string email, string password)
        {
            // Aquí iría la lógica para verificar las credenciales
            return Email == email && Password == password;
        }
    }

}
