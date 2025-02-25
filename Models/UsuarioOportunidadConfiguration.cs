using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class UsuarioOportunidadConfiguration : IEntityTypeConfiguration<UsuarioOportunidad>
{
    public void Configure(EntityTypeBuilder<UsuarioOportunidad> builder)
    {
        // Definir clave primaria compuesta
        builder.HasKey(uo => new { uo.UsuarioId, uo.OportunidadId });

        // Relación con Usuario (Muchos a Uno)
        builder.HasOne(uo => uo.Usuario)
            .WithMany(u => u.UsuariosOportunidades)
            .HasForeignKey(uo => uo.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra un Usuario, se eliminan sus relaciones

        // Relación con Oportunidad (Muchos a Uno)
        builder.HasOne(uo => uo.Oportunidad)
            .WithMany(o => o.UsuariosOportunidades)
            .HasForeignKey(uo => uo.OportunidadId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra una Oportunidad, se eliminan sus relaciones

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("UsuariosOportunidades");
    }
}
