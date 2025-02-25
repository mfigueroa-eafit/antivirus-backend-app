namespace Antivirus.Repositories;

using Antivirus.Models;
using System.Threading.Tasks;
using System.Collections.Generic;



public interface IInstitucionRepository
{
    Task<IEnumerable<Institucion>> GetAllAsync();
    Task<Institucion?> GetByIdAsync(int id);
    Task<Institucion> AddAsync(Institucion institucion);
    Task<Institucion?> UpdateAsync(int id, Institucion institucion);
    Task<bool> DeleteAsync(int id);
}
