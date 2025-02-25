using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class BootcampTematicaConfiguration : IEntityTypeConfiguration<BootcampTematica>
{
    public void Configure(EntityTypeBuilder<BootcampTematica> builder)
    {
        // Definir clave primaria compuesta
        builder.HasKey(bt => new { bt.BootcampId, bt.TematicaId });

        // Relación con Bootcamp (Muchos a Uno)
        builder.HasOne(bt => bt.Bootcamp)
            .WithMany(b => b.BootcampsTematicas)
            .HasForeignKey(bt => bt.BootcampId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación con Tematica (Muchos a Uno)
        builder.HasOne(bt => bt.Tematica)
            .WithMany(t => t.BootcampsTematicas)
            .HasForeignKey(bt => bt.TematicaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("BootcampTematicas");
    }
}
