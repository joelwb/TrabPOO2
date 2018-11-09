using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void EfetuarCalculo(decimal valorSoma, DateTime data)
        {
            decimal valor = valorSoma;
            if (next != null)
            {
                valor = Somar(valor, data);
                next.EfetuarCalculo(valor, data);
            }
        }

        protected abstract decimal Somar(decimal valor, DateTime data);
    }
}
