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
    public class RespositorioDespesaEntity : RepositorioGenericoEntity<Despesa, int> , IRepositorioHistorico<Despesa, int>


    {
        public RespositorioDespesaEntity(DbContext contexto) : base(contexto)
        {
        }

        public List<Despesa> ListarHistorico(string pessoaId, DateTime inicioMes, DateTime finalMes)
        {

           return  _contexto.Set<Despesa>().Where(p => p.Pessoa.Id == pessoaId && p.DataCompra > inicioMes && p.DataCompra < finalMes).ToList();
           

        }
    }
}
