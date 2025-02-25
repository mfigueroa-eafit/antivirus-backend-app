using Microsoft.AspNetCore.Mvc;
using Antivirus.Services;
using System.Security.Cryptography;
using System.Text;
using Antivirus.Dtos;
using AutoMapper;
using Antivirus.Models;
using System;
using System.Linq;



namespace Antivirus.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private const string DEFAULT_ROLE = "User";
        private readonly ApplicationDbContext _context; 
        private readonly AuthService _authService;
        private readonly IMapper _mapper; 
        public AuthController(ApplicationDbContext context, AuthService authService, IMapper mapper) { 
            _context = context; 
            _authService = authService;
            _mapper = mapper;
            }

        [HttpPost("register")]
        public IActionResult Register([FromBody]  UsuarioDto usuarioDto)
        {
            usuarioDto.Password = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(usuarioDto.Password)));
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Rol = DEFAULT_ROLE;
            _context.Usuarios.Add(usuario); _context.SaveChanges();
            return Ok(new { message = "Usuario registrado" });
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDto usuarioDto)
        {
            var existingUser = _context.Usuarios.FirstOrDefault(u => u.Correo == usuarioDto.Correo);
            if (existingUser == null || existingUser.Password != Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(usuarioDto.Password))))
            {
                return Unauthorized();
            }
            var token = _authService.GenerateJwtToken(existingUser);
            return Ok(new { token });
        }
    }
}