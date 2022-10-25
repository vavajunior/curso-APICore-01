using AutoMapper;
using curso_APICore_01.Data;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace curso_APICore_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult AdicionaSessao(NovoSessaoDTO itemDto)
        {
            var sessao = _mapper.Map<Sessao>(itemDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                var sessaoDto = _mapper.Map<ListaSessaoDTO>(sessao);
                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}
