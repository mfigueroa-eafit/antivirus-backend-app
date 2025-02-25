namespace Antivirus.Models;

public class BootcampTematica 
{ 
    public int BootcampId { get; set; } 
    public required Bootcamp Bootcamp { get; set; } 
    public int TematicaId { get; set; } 
    public required Tematica Tematica { get; set; } 
}
