using AutoMapper;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Linq;

namespace curso_APICore_01.ProfileMapper
{
    public class CinemaProfileMapper : Profile
    {
        public CinemaProfileMapper()
        {
            CreateMap<NovoCinemaDTO, Cinema>();
            CreateMap<EditaCinemaDTO, Cinema>();
            CreateMap<Cinema, ListaCinemaDTO>()
                .ForMember(c => c.Sessoes,
                    opts => opts.MapFrom(g => g.Sessoes.Select(s => new { s.Id, s.Filme.Titulo })));

        }
    }
}
