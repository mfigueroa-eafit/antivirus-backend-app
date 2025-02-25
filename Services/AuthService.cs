using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Antivirus.Dtos;
using Antivirus.Models;
using Microsoft.Extensions.Configuration;
using System;



namespace Antivirus.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config; public AuthService(IConfiguration config) => _config = config; public string GenerateJwtToken(Usuario user)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, user.Nombre), new Claim(ClaimTypes.Role, user.Rol) }; 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddHours(2), signingCredentials: creds); 
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}