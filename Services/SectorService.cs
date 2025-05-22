namespace Antivirus.Services;

using Antivirus.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using Antivirus.Repositories;
using Antivirus.Models;
using System.Linq;
public class SectorService : ISectorService
{
    private readonly ISectorRepository _repository;

    public SectorService(ISectorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SectorDto>> GetAllAsync()
    {
        var tipos = await _repository.GetAllAsync();
        return tipos.Select(t => new SectorDto { Id = t.Id, Descripcion = t.Descripcion });
    }

    public async Task<SectorDto?> GetByIdAsync(int id)
    {
        var tipo = await _repository.GetByIdAsync(id);
        return tipo != null ? new SectorDto { Id = tipo.Id, Descripcion = tipo.Descripcion } : null;
    }

    public async Task AddAsync(SectorDto sectorDto)
    {
        var sector = new Sector { Descripcion = sectorDto.Descripcion };
        await _repository.AddAsync(sector);
    }

    public async Task UpdateAsync(SectorDto sectorDto)
    {
        var sector = new Sector { Id = sectorDto.Id, Descripcion = sectorDto.Descripcion };
        await _repository.UpdateAsync(sector);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}