namespace Antivirus.Services;

using Antivirus.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;



public interface IInstitucionService
{
    Task<IEnumerable<InstitucionDto>> GetAllAsync();
    Task<InstitucionDto?> GetByIdAsync(int id);
    Task<InstitucionDto> AddAsync(InstitucionDto institucion);
    Task<InstitucionDto?> UpdateAsync(int id, InstitucionDto institucion);
    Task<bool> DeleteAsync(int id);
}
