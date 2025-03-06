namespace Antivirus.Dtos;
public class OportunidadDto {
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public int TipoOportunidadId { get; set; }
}