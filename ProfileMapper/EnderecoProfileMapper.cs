using AutoMapper;
using curso_APICore_01.DTOs;
using FilmesApi.Models;

namespace curso_APICore_01.ProfileMapper
{
    public class EnderecoProfileMapper : Profile
    {
        public EnderecoProfileMapper()
        {
            CreateMap<NovoEnderecoDTO, Endereco>();
            CreateMap<EditaEnderecoDTO, Endereco>();
            CreateMap<Endereco, ListaEnderecoDTO>();
        }
    }
}
