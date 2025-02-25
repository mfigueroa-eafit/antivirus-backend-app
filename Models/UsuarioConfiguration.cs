using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        // Definir clave primaria
        builder.HasKey(u => u.Id);

        // Configuración de las propiedades
        builder.Property(u => u.Nombre)
            .IsRequired()
            .HasMaxLength(100); // Longitud máxima opcional

        builder.Property(u => u.Correo)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(255); // Se recomienda hash de contraseñas

        builder.Property(u => u.Rol)
            .IsRequired()
            .HasMaxLength(50);

        // Restricción única en Correo (para evitar duplicados)
        builder.HasIndex(u => u.Correo)
            .IsUnique();

        // Relación con UsuarioOportunidad (Uno a Muchos)
        builder.HasMany(u => u.UsuariosOportunidades)
            .WithOne(uo => uo.Usuario)
            .HasForeignKey(uo => uo.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina un Usuario, se eliminan sus relaciones

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("Usuarios");
    }
}
