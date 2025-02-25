namespace Antivirus.Models;

using System.Collections.Generic;


public class Tematica { 
    public int Id { get; set; } 
    public required string Descripcion { get; set; } 

    public ICollection<BootcampTematica>? BootcampsTematicas { get; set; } 

} 