using System;
using System.ComponentModel.DataAnnotations;

namespace curso_APICore_01.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }

        public DateTime DataEncerramento { get; set; }  
    }
}
