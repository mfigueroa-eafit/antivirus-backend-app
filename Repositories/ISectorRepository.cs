namespace Antivirus.Repositories;

using Antivirus.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public interface ISectorRepository
{
    Task<IEnumerable<Sector>> GetAllAsync();
    Task<Sector?> GetByIdAsync(int id);
    Task AddAsync(Sector sector);
    Task UpdateAsync(Sector sector);
    Task DeleteAsync(int id);
}

public class SectorRepository : ISectorRepository
{
    private readonly ApplicationDbContext _context;

    public SectorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sector>> GetAllAsync()
    {
        return await _context.Sectores.ToListAsync();
    }

    public async Task<Sector?> GetByIdAsync(int id)
    {
        return await _context.Sectores.FindAsync(id);
    }

    public async Task AddAsync(Sector sector)
    {
        _context.Sectores.Add(sector);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sector sector)
    {
        _context.Sectores.Update(sector);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sector = await _context.Sectores.FindAsync(id);
        if (sector != null)
        {
            _context.Sectores.Remove(sector);
            await _context.SaveChangesAsync();
        }
    }
}
