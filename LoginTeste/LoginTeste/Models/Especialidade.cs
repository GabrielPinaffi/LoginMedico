using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginTeste.Models
{
    public class Especialidade
    {
        public int EspecialidadeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Especialidade")]
        public string Nome { get; set; }
    }
}