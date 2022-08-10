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
        public static List<Filme> listaFilmes = new List<Filme>();
        public static int index = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = index++;
            listaFilmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            return CreatedAtAction(nameof(BuscaFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult ListaFilmes()
        {
            return Ok(listaFilmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaFilme([FromRoute] int id)
        {
            var filme = listaFilmes.Find(x => x.Id == id);
            if (filme == null)
                return Ok(filme);
            else
                return NotFound();
        }
    }
}
