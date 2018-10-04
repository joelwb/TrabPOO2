
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CtrlMoney.ViewModel
{
    public class ParcelamentoViewModel
    {
        [Required(ErrorMessage = "Numero de Parcelas é um campo obrigatório")]
        [JsonProperty("numParcelamento")]
        public short NumParcelas { get; set; }

        [JsonProperty("cartaoId")]
        public int CartaoId { get; set; }
    }
}