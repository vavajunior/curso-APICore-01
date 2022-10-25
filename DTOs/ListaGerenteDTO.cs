using curso_APICore_01.Models;
using System.Collections.Generic;

namespace curso_APICore_01.DTOs
{
    public class ListaGerenteDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public object Cinemas { get; set; }
    }
}
