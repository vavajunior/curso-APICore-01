using AutoMapper;
using curso_APICore_01.Data;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using System;
using System.Collections.Generic;
using System.Linq;

namespace curso_APICore_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] NovoFilmeDTO itemDto)
        {
            var filme = _mapper.Map<Filme>(itemDto);

            _context.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult ListaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var filmes =  _context.Filmes.ToList();
            if (classificacaoEtaria.HasValue)
            {
                filmes = _context.Filmes.Where(f => f.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            var lista = _mapper.Map<List<ListaFilmeDTO>>(filmes);
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            var filme = _context.Find<Filme>(id);
            if (filme != null)
            {
                var itemDto = _mapper.Map<ListaFilmeDTO>(filme);
                itemDto.DataConsulta = DateTime.Now;
                return Ok(itemDto);
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult EditaFilme([FromRoute] int id, [FromBody] EditaFilmeDTO itemDto)
        {
            var filme = _context.Find<Filme>(id);
            if (filme == null)
                return NotFound();

            _mapper.Map(itemDto, filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveFilme(int id)
        {
            var filme = _context.Find<Filme>(id);
            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
