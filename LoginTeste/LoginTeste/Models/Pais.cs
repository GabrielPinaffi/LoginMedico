using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginTeste.Models
{
    public class Pais
    {
        public int PaisId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Pais")]
        public string Nome { get; set; }
    }
}