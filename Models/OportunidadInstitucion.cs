namespace Antivirus.Models;

public class OportunidadInstitucion { 

    public int OportunidadId { get; set; } 
    public required Oportunidad Oportunidad { get; set; } 
    public int InstitucionId { get; set; } 
    public required Institucion Institucion { get; set; } 
} 