namespace Antivirus.Services;

using Antivirus.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
public interface IOportunidadService {
    Task<IEnumerable<OportunidadDto>> GetAllAsync();
    Task<OportunidadDto?> GetByIdAsync(int id);
    Task AddAsync(OportunidadDto oportunidadDto);
    Task UpdateAsync(int id, OportunidadDto oportunidadDto);
    Task DeleteAsync(int id);
}
