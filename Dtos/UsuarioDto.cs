namespace Antivirus.Dtos;
public class UsuarioDto {

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string FechaNacimiento { get; set; } = null!;

    public string Correo { get; set; } = null!;
    public string Password { get; set; } = null!;

}