namespace Antivirus.Models;

public class UsuarioOportunidad { 
    public int UsuarioId { get; set; } 
    public required Usuario Usuario { get; set; } 
    public int OportunidadId { get; set; } 
    public required Oportunidad Oportunidad { get; set; } 
} 