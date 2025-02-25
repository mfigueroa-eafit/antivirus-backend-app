using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        // Definir la clave primaria
        builder.HasKey(b => b.Id);

        // Configurar propiedades requeridas con longitud máxima
        builder.Property(b => b.Nombre)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(b => b.Descripcion)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(b => b.Informacion)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(b => b.Costos)
            .IsRequired()
            .HasMaxLength(500);

        // Configurar relación con Institucion (uno a muchos)
        builder.HasOne(b => b.Institucion)
            .WithMany(i => i.Bootcamps)
            .HasForeignKey(b => b.InstitucionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configurar relación con BootcampTematica (uno a muchos)
        builder.HasMany(b => b.BootcampsTematicas)
            .WithOne(bt => bt.Bootcamp)
            .HasForeignKey(bt => bt.BootcampId)
            .OnDelete(DeleteBehavior.Cascade);

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("Bootcamps");
    }
}
