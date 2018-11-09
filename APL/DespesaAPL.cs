using Dominio;
using EntityAcessoDados;
using EntityAcessoDados.Repositorio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL
{
    public class DespesaAPL : IAPLGenerica
    {
        private CtrlMoneyDbContext db;
        private IRepositorioHistorico<Despesa, int> repositorioDespesa;


            public DespesaAPL()
            {
                db = new CtrlMoneyDbContext();
                repositorioDespesa = new RepositorioDespesaEntity(db);
            }

            public void Dispose()
            {
                db.Dispose();
            }

            public void Inserir(Despesa despesa)
            {
              
                 repositorioDespesa.Inserir(despesa);
            }

            //public Despesa SelecionarById(string id)
            //{
            //    return repositorioDespesa.SelecionarPorId(id);
            //}

            public void Alterar(Despesa despesa)
            {

                repositorioDespesa.Alterar(despesa);
            }

            public void Deletar(Despesa despesa)
            {

                repositorioDespesa.Excluir(despesa);
            }

            public List<Despesa> listar (string pessoaId, DateTime inicioMes, DateTime finalMes)
            {
               return repositorioDespesa.ListarHistorico (pessoaId,  inicioMes, finalMes);
            }
            
            public List<Despesa> ListarHistoricoPorCartao(int cartaoId, DateTime inicioMes, DateTime finalMes)
            {
                return ((RepositorioDespesaEntity)repositorioDespesa).ListarHistoricoPorCartao(cartaoId, inicioMes, finalMes);
            }
        }
    }



