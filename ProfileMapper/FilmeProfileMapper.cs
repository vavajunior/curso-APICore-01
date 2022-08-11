using AutoMapper;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;

namespace curso_APICore_01.ProfileMapper
{
    public class FilmeProfileMapper : Profile
    {
        public FilmeProfileMapper()
        {
            CreateMap<NovoFilmeDTO, Filme>();
            CreateMap<EditaFilmeDTO, Filme>();
            CreateMap<Filme, BuscaFilmeDTO>();
        }
    }
}
