using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CtrlMoney.ViewModel.Despesas
{
    public class SemParcelamentoViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        public bool Fixo { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A categoria da despesa é um campo obrigatório!")]
        [JsonProperty("categoria")]
        public CategoriaDespesa Categoria { get; set; }

        [Required(ErrorMessage = "Data da compra é um campo obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Campo não é uma data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [JsonProperty("datacompra")]
        [Display(Name = "Data de Compra")]
        public DateTime DataCompra { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Campo não é uma data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [JsonProperty("datapag")]
        [Display(Name = "Data de Pagamento")]
        public DateTime DataPag { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}