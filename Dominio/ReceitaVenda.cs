using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ReceitaVenda : AbstractClassCategoriaReceita
    {
        protected CategoriaReceita categoria = CategoriaReceita.Vendas;

        protected override decimal Somar(decimal valor, DateTime data)
        {
            var ReceitaMes = 0M;//vai pegar todas as receitas do mes passado
            var valorSomado = ReceitaMes + valor;
            return valorSomado;
        }
    }
}
