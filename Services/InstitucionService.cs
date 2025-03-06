namespace Antivirus.Services;

using AutoMapper;
using Antivirus.Repositories; 
using Antivirus.Dtos;
using Antivirus.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


public class InstitucionService : IInstitucionService
{
    private readonly IInstitucionRepository _repository;
    private readonly IMapper _mapper; // Automapper para convertir entre DTO y Entidad

    public InstitucionService(IInstitucionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InstitucionDto>> GetAllAsync()
    {
        var instituciones = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<InstitucionDto>>(instituciones);
    }

    public async Task<InstitucionDto?> GetByIdAsync(int id)
    {
        var institucion = await _repository.GetByIdAsync(id);
        return institucion == null ? null : _mapper.Map<InstitucionDto>(institucion);
    }

    public async Task<InstitucionDto> AddAsync(InstitucionDto institucionDto)
    {
        var institucion = _mapper.Map<Institucion>(institucionDto);
        var addedInstitucion = await _repository.AddAsync(institucion);
        return _mapper.Map<InstitucionDto>(addedInstitucion);
    }

    public async Task<InstitucionDto?> UpdateAsync(int id, InstitucionDto institucionDto)
    {
        var institucion = _mapper.Map<Institucion>(institucionDto);
        institucion.Id = id;
        var updatedInstitucion = await _repository.UpdateAsync(id, institucion);
        return updatedInstitucion == null ? null : _mapper.Map<InstitucionDto>(updatedInstitucion);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
