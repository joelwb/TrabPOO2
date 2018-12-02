using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CtrlMoney.ViewModel.Despesas
{
    public class ParcelamentoViewModel : DespesaViewModel
    {
        [Display(Name = "Número de Parcelas")]
        [Range(1, int.MaxValue,ErrorMessage ="Nº de parcelas deve ser maior que 1")]
        public int NumParcelas { get; set; }

        [Display(Name = "Cartao")]
        public int CartaoId { get; set; }
    }
}