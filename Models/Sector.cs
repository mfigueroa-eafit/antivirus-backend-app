namespace Antivirus.Models;

using System.Collections.Generic;


public class Sector { 
    public int Id { get; set; } 
    public required string Descripcion { get; set; } 
    public ICollection<Oportunidad>? Oportunidades { get; set; } = new List<Oportunidad>();

} 