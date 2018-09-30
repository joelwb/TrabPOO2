using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cartao
    {
        public Cartao()
        {
            this.Pessoas = new HashSet<Pessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Limite { get; set; }
        public DateTime DiaFechamento { get; set; }
        public DateTime DiaVencimento { get; set; }
        public long Numero { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}

