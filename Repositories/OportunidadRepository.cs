namespace Antivirus.Repositories;

using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
public class OportunidadRepository : IOportunidadRepository {
    private readonly ApplicationDbContext _context;

    public OportunidadRepository(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Oportunidad>> GetAllAsync() =>
        await _context.Set<Oportunidad>().ToListAsync();

    public async Task<Oportunidad?> GetByIdAsync(int id) =>
        await _context.Set<Oportunidad>().FindAsync(id);

    public async Task AddAsync(Oportunidad oportunidad) {
        await _context.Set<Oportunidad>().AddAsync(oportunidad);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Oportunidad oportunidad) {
        _context.Set<Oportunidad>().Update(oportunidad);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var entity = await GetByIdAsync(id);
        if (entity != null) {
            _context.Set<Oportunidad>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
