namespace Antivirus.Services;

using Antivirus.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

public interface ISectorService
{
    Task<IEnumerable<SectorDto>> GetAllAsync();
    Task<SectorDto?> GetByIdAsync(int id);
    Task AddAsync(SectorDto sectorDto);
    Task UpdateAsync(SectorDto sectorDto);
    Task DeleteAsync(int id);
}

