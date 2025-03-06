namespace Antivirus.Services;

using Antivirus.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

public interface ITipoOportunidadService
{
    Task<IEnumerable<TipoOportunidadDto>> GetAllAsync();
    Task<TipoOportunidadDto?> GetByIdAsync(int id);
    Task AddAsync(TipoOportunidadDto tipoOportunidadDto);
    Task UpdateAsync(TipoOportunidadDto tipoOportunidadDto);
    Task DeleteAsync(int id);
}

