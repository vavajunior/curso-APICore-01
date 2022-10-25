using System;

namespace curso_APICore_01.DTOs
{
    public class NovoSessaoDTO
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataEncerramento { get; set; }
    }
}
