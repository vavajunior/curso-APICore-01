using AutoMapper;
using curso_APICore_01.Data;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace curso_APICore_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
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

            return CreatedAtAction(nameof(BuscaFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<ListaFilmeDTO> ListaFilmes()
        {
            var lista = _mapper.Map<List<ListaFilmeDTO>>(_context.Filmes);
            return lista;
        }

        [HttpGet("{id}")]
        public IActionResult BuscaFilme([FromRoute] int id)
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
