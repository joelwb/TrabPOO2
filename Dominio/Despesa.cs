using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Despesa
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public bool Fixo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int PessoaId { get; set; }
        public CategoriaDespesa Categoria { get; set; }
        public FormaPag FormaPag { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
