namespace Antivirus.Repositories;

using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;




public class InstitucionRepository : IInstitucionRepository
{
    private readonly ApplicationDbContext _context;

    public InstitucionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Institucion>> GetAllAsync()
    {
        return await _context.Instituciones.ToListAsync();
    }

    public async Task<Institucion?> GetByIdAsync(int id)
    {
        return await _context.Instituciones.FindAsync(id);
    }

    public async Task<Institucion> AddAsync(Institucion institucion)
    {
        _context.Instituciones.Add(institucion);
        await _context.SaveChangesAsync();
        return institucion;
    }

    public async Task<Institucion?> UpdateAsync(int id, Institucion institucion)
    {
        var existing = await _context.Instituciones.FindAsync(institucion.Id);
        if (existing == null) return null;

        existing.Nombre = institucion.Nombre;
        existing.Ubicacion = institucion.Ubicacion;
        existing.Url = institucion.Url;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var institucion = await _context.Instituciones.FindAsync(id);
        if (institucion == null) return false;

        _context.Instituciones.Remove(institucion);
        await _context.SaveChangesAsync();
        return true;
    }
}
