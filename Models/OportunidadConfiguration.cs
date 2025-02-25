using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class OportunidadConfiguration : IEntityTypeConfiguration<Oportunidad>
{
    public void Configure(EntityTypeBuilder<Oportunidad> builder)
    {
        // Definir clave primaria
        builder.HasKey(o => o.Id);

        // Definir propiedades requeridas
        builder.Property(o => o.Nombre)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(o => o.Descripcion)
            .IsRequired()
            .HasMaxLength(1000);

        // Relación con TipoOportunidad (Muchos a Uno)
        builder.HasOne(o => o.TipoOportunidad)
            .WithMany(to => to.Oportunidades)
            .HasForeignKey(o => o.TipoOportunidadId)
            .OnDelete(DeleteBehavior.Restrict); // No eliminar en cascada

        // Relación con OportunidadInstitucion (Uno a Muchos)
        builder.HasMany(o => o.OportunidadesInstitucion)
            .WithOne(oi => oi.Oportunidad)
            .HasForeignKey(oi => oi.OportunidadId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra la oportunidad, se eliminan las relaciones

        // Relación con UsuarioOportunidad (Uno a Muchos)
        builder.HasMany(o => o.UsuariosOportunidades)
            .WithOne(uo => uo.Oportunidad)
            .HasForeignKey(uo => uo.OportunidadId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra la oportunidad, se eliminan las relaciones

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("Oportunidades");
    }
}
