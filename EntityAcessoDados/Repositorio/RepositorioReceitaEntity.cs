using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.Repositorio
{
    public class RepositorioReceitaEntity : RepositorioGenericoEntity<Receita, int>, IRepositorioHistorico<Receita, int>


    {
        public RepositorioReceitaEntity (DbContext contexto) : base(contexto)
        {
        }

        public List<Receita> ListarHistorico(string pessoaId, DateTime inicioMes, DateTime finalMes)
        {

            return _contexto.Set<Receita>().Where(p => p.Pessoa.Id == pessoaId && p.DataRecebimento > inicioMes && p.DataRecebimento < finalMes).ToList();


        }
    }

}
