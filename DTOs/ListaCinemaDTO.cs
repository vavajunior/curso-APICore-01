using curso_APICore_01.Models;
using FilmesApi.Models;

namespace curso_APICore_01.DTOs
{
    public class ListaCinemaDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ListaEnderecoDTO Endereco { get; set; }
        public ListaGerenteDTO Gerente { get; set; }

        public object Sessoes { get; set; }
    }
}
