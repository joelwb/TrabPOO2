using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Parcelamento : Despesa
    {
        public short NumParcelas { get; set; }
        public int CartaoId { get; set; }

        public virtual Cartao Cartao { get; set; }
    }
}
