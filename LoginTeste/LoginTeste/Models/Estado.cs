using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginTeste.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Estado")]
        public string Nome { get; set; }

        public int PaisId { get; set; }

        [ForeignKey("PaisId")]
        public virtual Pais Pais { get; set; }
    }
}