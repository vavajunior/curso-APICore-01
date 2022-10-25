using AutoMapper;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;
using System.Linq;

namespace curso_APICore_01.ProfileMapper
{
    public class GerenteProfileMapper : Profile
    {
        public GerenteProfileMapper()
        {
            CreateMap<Gerente, ListaGerenteDTO>()
                .ForMember(g => g.Cinemas,
                    opts => opts.MapFrom(g => g.Cinemas.Select(c => new { c.Id, c.Nome })));
        }
    }
}
