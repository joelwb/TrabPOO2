using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CtrlMoney.ViewModel.Despesas
{
    public class SemParcelamentoViewModel : DespesaViewModel
    {
        [DataType(DataType.Date, ErrorMessage = "Campo não é uma data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [JsonProperty("datapag")]
        [Display(Name = "Data de Pagamento")]
        public DateTime DataPag { get; set; }
    }
}