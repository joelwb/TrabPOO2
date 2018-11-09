using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IRepositorioHistorico <TEntidade, TChave> : IRepositorioGenerico <TEntidade, TChave>
         where TEntidade : class
    {
        List<TEntidade> ListarHistorico(string pessoaId, DateTime inicioMes, DateTime finalMes);
       
    }
}
