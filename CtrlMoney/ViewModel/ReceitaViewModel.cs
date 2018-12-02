using Dominio;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CtrlMoney.ViewModel
{
    public class ReceitaViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fixo")]
        public bool Fixo { get; set; }

        [Required(ErrorMessage = "Data de recebimento é um campo obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Campo não é uma data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [JsonProperty("dataRecebimento")]
        [Display(Name ="Data de Recebimento")]
        public DateTime DataRecebimento { get; set; }

        [Required(ErrorMessage = "Valor é um campo obrigatório")]
        [JsonProperty("valor")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor deve ser maior que 0")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Categoria é um campo obrigatório")]
        [JsonProperty("categoria")]
        public CategoriaReceita Categoria { get; set; }

    }
}