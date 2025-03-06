namespace Antivirus.Services;

using Antivirus.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using Antivirus.Repositories;
using Antivirus.Models;
using System.Linq;
public class TipoOportunidadService : ITipoOportunidadService
{
    private readonly ITipoOportunidadRepository _repository;

    public TipoOportunidadService(ITipoOportunidadRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TipoOportunidadDto>> GetAllAsync()
    {
        var tipos = await _repository.GetAllAsync();
        return tipos.Select(t => new TipoOportunidadDto { Id = t.Id, Descripcion = t.Descripcion });
    }

    public async Task<TipoOportunidadDto?> GetByIdAsync(int id)
    {
        var tipo = await _repository.GetByIdAsync(id);
        return tipo != null ? new TipoOportunidadDto { Id = tipo.Id, Descripcion = tipo.Descripcion } : null;
    }

    public async Task AddAsync(TipoOportunidadDto tipoOportunidadDto)
    {
        var tipoOportunidad = new TipoOportunidad { Descripcion = tipoOportunidadDto.Descripcion };
        await _repository.AddAsync(tipoOportunidad);
    }

    public async Task UpdateAsync(TipoOportunidadDto tipoOportunidadDto)
    {
        var tipoOportunidad = new TipoOportunidad { Id = tipoOportunidadDto.Id, Descripcion = tipoOportunidadDto.Descripcion };
        await _repository.UpdateAsync(tipoOportunidad);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}