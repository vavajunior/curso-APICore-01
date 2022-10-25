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
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerente.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                var gerenteDto = _mapper.Map<ListaGerenteDTO>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();
        }
    }
}
