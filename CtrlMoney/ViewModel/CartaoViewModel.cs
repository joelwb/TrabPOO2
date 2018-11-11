using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CtrlMoney.ViewModel
{
    public class CartaoViewModel
    {
        [JsonProperty("numParcelamento")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Limite é um campo obrigatório")]
        [JsonProperty("limite")]
        public decimal Limite { get; set; }

        [Required(ErrorMessage = "Dia de fechamento é um campo obrigatório")]
        [JsonProperty("diaFechamento")]
        [Range(1, 28, ErrorMessage = "O dia tem que ser entre 1 e 28.")]
        public int DiaFechamento { get; set; }

        [Required(ErrorMessage = "Vencimento é um campo obrigatório")]
        [JsonProperty("diaVencimento")]
        [Range(1, 28, ErrorMessage = "O dia tem que ser entre 1 e 28.")]
        public int DiaVencimento { get; set; }

        [Required(ErrorMessage = "Numero é um campo obrigatório")]
        [JsonProperty("numero")]
        public long Numero { get; set; }
    }
}