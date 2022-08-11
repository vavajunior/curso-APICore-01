using System;
using System.ComponentModel.DataAnnotations;

namespace curso_APICore_01.DTOs
{
    public class BuscaFilmeDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }

        public DateTime DataConsulta { get; set; }
    }
}
