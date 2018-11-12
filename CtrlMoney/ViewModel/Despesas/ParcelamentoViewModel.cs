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
        public int NumParcelas { get; set; }

        [Display(Name = "Cartao")]
        public int CartaoId { get; set; }
    }
}