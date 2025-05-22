using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;

public class SectorConfiguration : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> builder)
    {
        // Definir clave primaria
        builder.HasKey(to => to.Id);

        // Configuración de la propiedad Descripcion
        builder.Property(to => to.Descripcion)
            .IsRequired()
            .HasMaxLength(255); // Longitud máxima opcional

        // Relación con Oportunidad (Uno a Muchos)
        builder.HasMany(to => to.Oportunidades)
            .WithOne(o => o.Sector)
            .HasForeignKey(o => o.SectorId)
            .OnDelete(DeleteBehavior.Restrict); // Evita que se eliminen oportunidades al borrar un Sector

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("Sectores");
    }
}
