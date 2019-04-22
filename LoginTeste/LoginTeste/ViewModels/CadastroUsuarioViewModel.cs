using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace LoginTeste.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100,ErrorMessage = "Max 100, burrão")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(100, ErrorMessage = "Max 100, burrão")]
        public string login { get; set; }

        [Required(ErrorMessage = "Informe o senha")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Max 100, burrão")]
        [MinLength(4, ErrorMessage = "Min 4, burrin")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [MinLength(4, ErrorMessage = "Min 4, burrin")]
        [Compare(nameof(senha), ErrorMessage = "Senhas não coincidem, burraço")]
        public string ConfirmacaoSenha { get; set; }
    }
}