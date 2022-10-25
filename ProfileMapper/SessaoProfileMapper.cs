using AutoMapper;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;

namespace curso_APICore_01.ProfileMapper
{
    public class SessaoProfileMapper : Profile
    {
        public SessaoProfileMapper()
        {
            CreateMap<NovoSessaoDTO, Sessao>();
            CreateMap<Sessao, ListaSessaoDTO>()
                .ForMember(s => s.DataInicio,
                            opts => opts.MapFrom(s => s.DataEncerramento.AddMinutes(s.Filme.Duracao * (-1))));
        }
    }
}
