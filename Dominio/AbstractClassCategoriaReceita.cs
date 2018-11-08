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
            if (next != null)
            {
                valorSoma = Somar(valorSoma, data);
                next.EfetuarCalculo(valorSoma, data);
            }
        }

        protected abstract decimal Somar(decimal valor, DateTime data);
    }
}
