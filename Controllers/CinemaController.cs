using AutoMapper;
using curso_APICore_01.Data;
using curso_APICore_01.DTOs;
using curso_APICore_01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace curso_APICore_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
  

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] NovoCinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeFilme)
        {
            var cinemas = _context.Cinemas.ToList();
            if (!string.IsNullOrEmpty(nomeFilme))
            {
                var query = from c in _context.Cinemas
                            where c.Sessoes.Any(s => s.Filme.Titulo.Equals(nomeFilme))
                            select c;
                cinemas = query.ToList();
            }
            var listaCinemaDTOs = _mapper.Map<List<ListaCinemaDTO>>(cinemas);
            return Ok(listaCinemaDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema != null)
            {
                var cinemaDto = _mapper.Map<ListaCinemaDTO>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] EditaCinemaDTO cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
