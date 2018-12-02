using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ReceitaPensao : AbstractClassCategoriaReceita
    {
        protected CategoriaReceita categoria = CategoriaReceita.Pensao;

        protected override Dictionary<string, decimal> Adicionar(Dictionary<string, decimal> dicionario, List<Receita> receitas)
        {
            dicionario[categoria.ToString()] = receitas.Where(r => r.Categoria == categoria).Sum(r => r.Valor);
            return dicionario;
        }
    }
}
