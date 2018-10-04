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

        [JsonProperty("pessoaId")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Data de recebimento é um campo obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "Campo não é uma data")]
        [JsonProperty("dataRecebimento")]
        public DateTime DataRecebimento { get; set; }

        [Required(ErrorMessage = "Valor é um campo obrigatório")]
        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Categoria é um campo obrigatório")]
        [JsonProperty("categoria")]
        public CategoriaReceita Categoria { get; set; }

    }
}