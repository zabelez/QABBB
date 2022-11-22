using System;
using Microsoft.IdentityModel.Tokens;
using QABBB.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NuGet.Common;
using QABBB.Data;
using QABBB.API.Models.User;

namespace QABBB.Domain.Services
{
    public class AuthServices
    {
        private readonly AdminServices _adminServices;
        private readonly QABBBContext _context;

        public AuthServices(QABBBContext context)
        {
            _context = context;
            _adminServices = new AdminServices(_context);
        }

        public string BuildToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfasdfasdfasdfasdf"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, user.IdPerson.ToString())
            };

            if (_adminServices.isAdmin(user))
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(5000),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }

        public List<string>? getClaims(int idPerson)
        {
            List<string> claims = new List<string>();

            Admin? admin = _adminServices.findByIdUser(idPerson);
            
            if (admin != null)
                claims.Add("Admin");

            return claims;
        }

        public List<string>? getClaims(User user){
            return getClaims(user.IdPerson);
        }

        public List<string>? getClaims(UserDTO user){
            return getClaims(user.IdPerson);
        }
    }
}

