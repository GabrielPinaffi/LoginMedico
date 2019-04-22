using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTeste.ViewModels
{
    public class LoginViewModels
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage ="Entre com seu Login")]
        public string login{ get; set; }

        [Required(ErrorMessage = "Entre com sua Senha")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage ="Pelo menos 4 caracteres, burrin")]
        public string Senha { get; set; }

    }
}