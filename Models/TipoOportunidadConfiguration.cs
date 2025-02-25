using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;

public class TipoOportunidadConfiguration : IEntityTypeConfiguration<TipoOportunidad>
{
    public void Configure(EntityTypeBuilder<TipoOportunidad> builder)
    {
        // Definir clave primaria
        builder.HasKey(to => to.Id);

        // Configuración de la propiedad Descripcion
        builder.Property(to => to.Descripcion)
            .IsRequired()
            .HasMaxLength(255); // Longitud máxima opcional

        // Relación con Oportunidad (Uno a Muchos)
        builder.HasMany(to => to.Oportunidades)
            .WithOne(o => o.TipoOportunidad)
            .HasForeignKey(o => o.TipoOportunidadId)
            .OnDelete(DeleteBehavior.Restrict); // Evita que se eliminen oportunidades al borrar un TipoOportunidad

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("TiposOportunidad");
    }
}
