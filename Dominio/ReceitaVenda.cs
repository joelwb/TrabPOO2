using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ReceitaVenda : AbstractClassCategoriaReceita
    {
        public ReceitaVenda(string id)
        {
            IdUser = id;
        }
        private string IdUser;
        private readonly IRepositorioGenerico<Receita, int> _repositorioReceita;
        protected CategoriaReceita categoria = CategoriaReceita.Vendas;

        protected override Dictionary<string, object> Adicionar(Dictionary<string, object> dicionario, DateTime data)
        {
            dicionario["Venda"] = _repositorioReceita.Selecionar().Where(x => x.DataRecebimento.Month == data.Month && x.Categoria.Equals(categoria) && x.PessoaId.Equals(IdUser)).Select(x => x.Valor).Sum();
            return dicionario;
        }
    }
}
