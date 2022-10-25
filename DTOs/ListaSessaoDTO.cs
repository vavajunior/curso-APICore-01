using System;

namespace curso_APICore_01.DTOs
{
    public class ListaSessaoDTO
    {
        public int Id { get; set; }
        public ListaCinemaDTO Cinema { get; set; }  
        public ListaFilmeDTO Filme { get; set; }
        public DateTime DataEncerramento { get; set; }
        public DateTime DataInicio { get; set; }
    }
}
