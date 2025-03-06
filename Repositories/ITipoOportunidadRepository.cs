namespace Antivirus.Repositories;

using Antivirus.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public interface ITipoOportunidadRepository
{
    Task<IEnumerable<TipoOportunidad>> GetAllAsync();
    Task<TipoOportunidad?> GetByIdAsync(int id);
    Task AddAsync(TipoOportunidad tipoOportunidad);
    Task UpdateAsync(TipoOportunidad tipoOportunidad);
    Task DeleteAsync(int id);
}

public class TipoOportunidadRepository : ITipoOportunidadRepository
{
    private readonly ApplicationDbContext _context;

    public TipoOportunidadRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TipoOportunidad>> GetAllAsync()
    {
        return await _context.TipoOportunidades.ToListAsync();
    }

    public async Task<TipoOportunidad?> GetByIdAsync(int id)
    {
        return await _context.TipoOportunidades.FindAsync(id);
    }

    public async Task AddAsync(TipoOportunidad tipoOportunidad)
    {
        _context.TipoOportunidades.Add(tipoOportunidad);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TipoOportunidad tipoOportunidad)
    {
        _context.TipoOportunidades.Update(tipoOportunidad);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipoOportunidad = await _context.TipoOportunidades.FindAsync(id);
        if (tipoOportunidad != null)
        {
            _context.TipoOportunidades.Remove(tipoOportunidad);
            await _context.SaveChangesAsync();
        }
    }
}
