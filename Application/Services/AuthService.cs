//using Application.DTOs;
//using Domain;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;
//using Domain.Models;

//namespace Application.Services
//{
//    public class AuthService
//    {
//        private readonly string _secret;

//        public AuthService(string secret)
//        {
//            _secret = secret;
//        }

//        public string Authenticate(string username, string password)
//        {
//            var user = GetUserFromDatabase(username, password);

//            if (user == null)
//                return null;

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_secret);

//            var claims = new List<Claim>
//        {
//            new Claim(ClaimTypes.Name, user.Username)
//        };

//            // Agregar roles al token
//            foreach (var role in user.Roles)
//            {
//                claims.Add(new Claim(ClaimTypes.Role, role));
//            }

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(claims),
//                Expires = DateTime.UtcNow.AddHours(1),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }
//    }
//}