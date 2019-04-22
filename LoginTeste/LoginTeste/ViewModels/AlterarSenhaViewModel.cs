using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginTeste.ViewModels
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "Informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informe a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Repita a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova Senha")]
        [Compare(nameof(NovaSenha), ErrorMessage = "As senha não coincidem")]
        public string ConfirmacaoSenha { get; set; }

    }
}