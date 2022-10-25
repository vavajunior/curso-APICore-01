using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace curso_APICore_01.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual List<Cinema> Cinemas { get; set; }
    }
}
