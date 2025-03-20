namespace Antivirus.Services;

using AutoMapper;
using Antivirus.Repositories; 
using Antivirus.Dtos;
using Antivirus.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class OportunidadService : IOportunidadService {
    private readonly IOportunidadRepository _repository;

    private readonly ITipoOportunidadRepository _tipoOportunidadRepository;

    public OportunidadService(IOportunidadRepository repository, ITipoOportunidadRepository tipoOportunidadRepository) {
        _repository = repository;
        _tipoOportunidadRepository = tipoOportunidadRepository;
    }

    public async Task<IEnumerable<OportunidadDto>> GetAllAsync() =>
        (await _repository.GetAllAsync()).Select(o => new OportunidadDto {
            Id = o.Id,
            Nombre = o.Nombre,
            Descripcion = o.Descripcion,
            Logo = o.Logo,
            Url = o.Url,
            TipoOportunidadId = o.TipoOportunidadId
        });

    public async Task<OportunidadDto?> GetByIdAsync(int id) {
        var oportunidad = await _repository.GetByIdAsync(id);
        return oportunidad == null ? null : new OportunidadDto {
            Id = oportunidad.Id,
            Nombre = oportunidad.Nombre,
            Descripcion = oportunidad.Descripcion,
            Logo = oportunidad.Logo,
            Url = oportunidad.Url,
            TipoOportunidadId = oportunidad.TipoOportunidadId
        };
    }

    public async Task AddAsync(OportunidadDto oportunidadDto) {
        var oportunidad = new Oportunidad {
            Nombre = oportunidadDto.Nombre,
            Descripcion = oportunidadDto.Descripcion,
            Logo = oportunidadDto.Logo,
            Url = oportunidadDto.Url,
            TipoOportunidad = await _tipoOportunidadRepository.GetByIdAsync(oportunidadDto.TipoOportunidadId),
            TipoOportunidadId = oportunidadDto.TipoOportunidadId
        };
        await _repository.AddAsync(oportunidad);
    }

    public async Task UpdateAsync(int id, OportunidadDto oportunidadDto) {
        var oportunidad = await _repository.GetByIdAsync(id);
        if (oportunidad != null) {
            oportunidad.Nombre = oportunidadDto.Nombre;
            oportunidad.Descripcion = oportunidadDto.Descripcion;
            oportunidad.Logo = oportunidadDto.Logo;
            oportunidad.Url = oportunidadDto.Url;
            oportunidad.TipoOportunidadId = oportunidadDto.TipoOportunidadId;
            await _repository.UpdateAsync(oportunidad);
        }
    }

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}