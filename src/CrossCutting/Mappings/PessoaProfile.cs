using AutoMapper;
using Domain.Dtos.Pessoa;
using Domain.Entities;
using Domain.Models;

namespace CrossCutting.Mappings;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<PessoaEntity, PessoaModel>().ReverseMap();
        CreateMap<PessoaDto, PessoaEntity>().ReverseMap();
        CreateMap<PessoaDtoResult, PessoaEntity>().ReverseMap();
        CreateMap<PessoaCreateResultDto, PessoaEntity>().ReverseMap();
        CreateMap<PessoaUpdateResultDto, PessoaEntity>().ReverseMap();
        CreateMap<PessoaModel, PessoaDto>().ReverseMap();
        CreateMap<PessoaModel, PessoaUpdateDto>().ReverseMap();

    }
}