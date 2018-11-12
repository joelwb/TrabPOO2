using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Receita
    {
        public int Id { get; set; }
        public bool Fixo { get; set; }
        public DateTime DataRecebimento { get; set; }
        public decimal Valor { get; set; }
        public string Nome { get; set; }
        public CategoriaReceita Categoria { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public string PessoaId { get; set; }
    }
}
