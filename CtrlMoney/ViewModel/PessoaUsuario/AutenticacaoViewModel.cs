using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CtrlMoney.ViewModel.PessoaUsuario
{
    public class AutenticacaoViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(150, ErrorMessage = "O email não pode ter mais que 150 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="A senha deve ter ao menos 6 caracters")]
        public string Senha { get; set; }

        [Display(Name ="Lembrar-me")]
        public bool Lembrar { get; set; }
    }
}