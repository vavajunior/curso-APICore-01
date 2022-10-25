using System.ComponentModel.DataAnnotations;

namespace curso_APICore_01.DTOs
{
    public class NovoCinemaDTO
    {
        [Required(ErrorMessage = "O campo nome do cinema é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
