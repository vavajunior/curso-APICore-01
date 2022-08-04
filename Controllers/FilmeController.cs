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

        [HttpPost]
        public void AdicionaFilme([FromBody]Filme filme)
        {
            listaFilmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }
    }
}
