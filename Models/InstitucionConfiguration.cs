using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class InstitucionConfiguration : IEntityTypeConfiguration<Institucion>
{
    public void Configure(EntityTypeBuilder<Institucion> builder)
    {
        // Definir clave primaria
        builder.HasKey(i => i.Id);

        // Definir propiedades requeridas
        builder.Property(i => i.Nombre)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(i => i.Ubicacion)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(i => i.Url)
            .IsRequired()
            .HasMaxLength(500);

        // Relación con OportunidadInstitucion (Uno a Muchos)
        builder.HasMany(i => i.OportunidadesInstitucion)
            .WithOne(oi => oi.Institucion)
            .HasForeignKey(oi => oi.InstitucionId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra la institución, se eliminan las relaciones

        // Relación con Bootcamp (Uno a Muchos)
        builder.HasMany(i => i.Bootcamps)
            .WithOne(b => b.Institucion)
            .HasForeignKey(b => b.InstitucionId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra la institución, se eliminan los bootcamps

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("Instituciones");
    }
}
