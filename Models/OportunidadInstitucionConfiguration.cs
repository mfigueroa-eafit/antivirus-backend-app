using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antivirus.Models;
public class OportunidadInstitucionConfiguration : IEntityTypeConfiguration<OportunidadInstitucion>
{
    public void Configure(EntityTypeBuilder<OportunidadInstitucion> builder)
    {
        // Definir clave primaria compuesta
        builder.HasKey(oi => new { oi.OportunidadId, oi.InstitucionId });

        // Relación con Oportunidad (Muchos a Uno)
        builder.HasOne(oi => oi.Oportunidad)
            .WithMany(o => o.OportunidadesInstitucion)
            .HasForeignKey(oi => oi.OportunidadId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra una oportunidad, eliminar la relación

        // Relación con Institucion (Muchos a Uno)
        builder.HasOne(oi => oi.Institucion)
            .WithMany(i => i.OportunidadesInstitucion)
            .HasForeignKey(oi => oi.InstitucionId)
            .OnDelete(DeleteBehavior.Cascade); // Si se borra una institución, eliminar la relación

        // Nombre de la tabla en la BD (opcional)
        builder.ToTable("OportunidadesInstituciones");
    }
}
