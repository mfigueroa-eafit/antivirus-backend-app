using AutoMapper;
using Antivirus.Models;
using Antivirus.Dtos;

namespace Antivirus.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        // Mapeo de Usuario
        CreateMap<Usuario, UsuarioDto>().ReverseMap();

        // Mapeo de Institucion
        CreateMap<Institucion, InstitucionDto>().ReverseMap();

        // Mapeo de Oportunidad
        CreateMap<Oportunidad, OportunidadDto>().ReverseMap();

        // Mapeo de Tipod Oportunidad
        CreateMap<TipoOportunidad, TipoOportunidadDto>().ReverseMap();

    }
}

