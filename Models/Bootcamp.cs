namespace Antivirus.Models;

using System.Collections.Generic;


public class Bootcamp { 
    public int Id { get; set; } 
    public required string Nombre { get; set; } 
    public required string Descripcion { get; set; } 
    public required string Informacion { get; set; } 
    public required string Costos { get; set; } 
    public int InstitucionId { get; set; } 
    public required Institucion Institucion { get; set; } 

    public ICollection<BootcampTematica>? BootcampsTematicas { get; set; } 
 
} 