using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginTeste.ViewModels
{
    public class CadastroCidadeViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Max 100, burrão")]
        public string Nome { get; set; }
    }
}