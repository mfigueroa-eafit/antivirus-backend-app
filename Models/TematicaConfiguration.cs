using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class TematicaConfiguration : IEntityTypeConfiguration<Tematica>
{
    public void Configure(EntityTypeBuilder<Tematica> builder)
    {
        // Definir la clave primaria
        builder.HasKey(t => t.Id);

        // Configurar la propiedad Descripcion como requerida con longitud máxima
        builder.Property(t => t.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        // Configurar la relación con BootcampTematica (uno a muchos)
        builder.HasMany(t => t.BootcampsTematicas)
            .WithOne(bt => bt.Tematica)
            .HasForeignKey(bt => bt.TematicaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("Tematicas");
    }
}
