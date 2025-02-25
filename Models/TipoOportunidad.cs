namespace Antivirus.Models;

using System.Collections.Generic;


public class TipoOportunidad { 
    public int Id { get; set; } 
    public required string Descripcion { get; set; } 
    public ICollection<Oportunidad>? Oportunidades { get; set; } 
} 