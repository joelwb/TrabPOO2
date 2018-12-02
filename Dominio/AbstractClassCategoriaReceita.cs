using System;
using System.Collections.Generic;

namespace Dominio
{
    public abstract class AbstractClassCategoriaReceita
    {
        protected AbstractClassCategoriaReceita next;

        public void SetNext(AbstractClassCategoriaReceita forma)
        {
            if (next == null)
            {
                next = forma;
            }
            else
            {
                next.SetNext(forma);
            }
        }

        public void EfetuarCalculo(Dictionary<string,decimal> dicReceitas, List<Receita> receitas)
        {
            dicReceitas = Adicionar(dicReceitas, receitas);
            if (next != null)
            {
                next.EfetuarCalculo(dicReceitas, receitas);
            }
        }

        protected abstract Dictionary<string, decimal> Adicionar(Dictionary<string, decimal> dicionario, List<Receita> receitas);
    }
}
