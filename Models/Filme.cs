using System.ComponentModel.DataAnnotations;

namespace curso_APICore_01.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range(1, 300, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 300 minutos")]
        public int Duracao { get; set; }
    }
}
