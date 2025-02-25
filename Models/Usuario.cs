using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;


namespace Antivirus.Models;
public class Usuario { 
    public int Id { get; set; } 
    public required string Nombre { get; set; } 
    public required string Correo { get; set; } 
    public required string Password { get; set; } 
    public required string Rol { get; set; } 
    public ICollection<UsuarioOportunidad>? UsuariosOportunidades { get; set; } 
} 