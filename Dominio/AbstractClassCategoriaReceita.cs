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

        public void EfetuarCalculo(Dictionary<string,object> dicReceitas, DateTime data)
        {
            if (next != null)
            {
                dicReceitas = Adicionar(dicReceitas, data);
                next.EfetuarCalculo(dicReceitas, data);
            }
        }

        protected abstract Dictionary<string, object> Adicionar(Dictionary<string, object> dicionario, DateTime data);
    }
}
