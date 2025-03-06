namespace Antivirus.Repositories;

using Antivirus.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
public interface IOportunidadRepository {
    Task<IEnumerable<Oportunidad>> GetAllAsync();
    Task<Oportunidad?> GetByIdAsync(int id);
    Task AddAsync(Oportunidad oportunidad);
    Task UpdateAsync(Oportunidad oportunidad);
    Task DeleteAsync(int id);
}