using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pessoa
    {
        public Pessoa()
        {
            this.Cartoes = new HashSet<Cartao>();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }

        public virtual ICollection<Cartao> Cartoes { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Despesa> Despesas { get; set; }
        public virtual ICollection<Receita> Receitas { get; set; }
    }
}
