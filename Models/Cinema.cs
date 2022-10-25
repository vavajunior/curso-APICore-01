using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace curso_APICore_01.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Gerente Gerente { get; set; }

        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }

        public virtual List<Sessao> Sessoes { get; set; }
    }
}
