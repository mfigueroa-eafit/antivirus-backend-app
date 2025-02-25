namespace Antivirus.Models;

using System.Collections.Generic;


public class Institucion { 
    public int Id { get; set; } 
    public required string Nombre { get; set; } 
    public required string Ubicacion { get; set; } 
    public required string Url { get; set; } 
    public ICollection<OportunidadInstitucion>? OportunidadesInstitucion { get; set; } 
    public ICollection<Bootcamp>? Bootcamps { get; set; } 
} 
