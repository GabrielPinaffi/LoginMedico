using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginTeste.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Max 100, burrão")]
        [Display(Name = "Cidade")]
        public string Nome { get; set; }
        
        public int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Estado Estado { get; set; }
    }
}