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
    class DespesaAPL : IAPLGenerica
    {
        private CtrlMoneyDbContext db;
        private IRepositorioGenerico<Despesa, string> repositorioDespesa;


            public DespesaAPL()
            {
                db = new CtrlMoneyDbContext();
                repositorioDespesa = new DespesaReposEntity (db);
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
        }
    }



