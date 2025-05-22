
using Microsoft.EntityFrameworkCore;

namespace Antivirus.Models;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
    public DbSet<Bootcamp> Bootcamps { get; set; }
    public DbSet<BootcampTematica> BootcampsTematicas { get; set; }
    public DbSet<Institucion> Instituciones { get; set; }
    public DbSet<Oportunidad> Oportunidades { get; set; }
    public DbSet<OportunidadInstitucion> OportunidadesInstitucion { get; set; }
    public DbSet<Tematica> Tematicas { get; set; }
    public DbSet<TipoOportunidad> TipoOportunidades { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioOportunidad> UsuariosOportunidades { get; set; }
    public DbSet<Sector> Sectores { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Bootcamp
        modelBuilder.ApplyConfiguration(new BootcampConfiguration());

        //BootcampTematica
        modelBuilder.ApplyConfiguration(new BootcampTematicaConfiguration());

        //Institucion
        modelBuilder.ApplyConfiguration(new InstitucionConfiguration());

        //Oportunidad
        modelBuilder.ApplyConfiguration(new OportunidadConfiguration());

        //Oportunidad Institucion
        modelBuilder.ApplyConfiguration(new OportunidadInstitucionConfiguration());

        //Tematica
        modelBuilder.ApplyConfiguration(new TematicaConfiguration());

        //Tipo Oportunidad
        modelBuilder.ApplyConfiguration(new TipoOportunidadConfiguration());

        //Usuario
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        //Usuario Oportunidad 
        modelBuilder.ApplyConfiguration(new UsuarioOportunidadConfiguration());

        //Sector
        modelBuilder.ApplyConfiguration(new SectorConfiguration());

    }

}