namespace Antivirus.Models;

using System.Collections.Generic;

public class Oportunidad { 
    public int Id { get; set; } 
    public required string Nombre { get; set; } 
    public required string Descripcion { get; set; } 

    public required string Logo { get; set; } = "";

    public required string Url { get; set; } = "";
    public int TipoOportunidadId { get; set; } 
    public required TipoOportunidad? TipoOportunidad { get; set; } 
    public ICollection<OportunidadInstitucion>? OportunidadesInstitucion { get; set; } 
    public ICollection<UsuarioOportunidad>? UsuariosOportunidades { get; set; } 
} 