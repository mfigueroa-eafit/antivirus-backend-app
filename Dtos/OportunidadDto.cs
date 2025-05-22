namespace Antivirus.Dtos;
public class OportunidadDto {
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }

    public required string Logo { get; set; }

    public required string Url { get; set; }
    public int TipoOportunidadId { get; set; }

     public int SectorId { get; set; }
}