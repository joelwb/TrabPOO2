using CtrlMoney.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CtrlMoney.ViewModel.PessoaUsuario
{
    public class PessoaUsuarioViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Campo não é uma data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "O login é obrigatório")]
        [EmailAddress(ErrorMessage = "Email informado não é valido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email informado não é valido")]
        [MaxLength(150, ErrorMessage = "O login não pode ter mais que 150 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter ao menos 6 caracters")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"[0-9.-]{14}", ErrorMessage = "CPF deve conter apenas números")]
        [CPF(ErrorMessage = "CPF não é valido")]
        public string CPF { get; set; }
    }
}