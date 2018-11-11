using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ReceitaOutros : AbstractClassCategoriaReceita
    {
        public ReceitaOutros(string id)
        {
            IdUser = id;
        }
        private string IdUser;
        private readonly IRepositorioGenerico<Receita, int> _repositorioReceita;
        protected CategoriaReceita categoria = CategoriaReceita.Outros;

        protected override decimal Somar(decimal valor, DateTime data)
        {
            var ReceitaMes = _repositorioReceita.Selecionar().Where(x => x.Categoria.Equals(categoria) /*&& x.PessoaId.Equals(...)*/).Select(x=> x.Valor).Sum();//vai pegar todas as receitas do mes passado
            var valorSomado = ReceitaMes + valor;
            return valorSomado;
        }
    }
}
