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
    class ReceitaAPL : IAPLGenerica
    {
        private CtrlMoneyDbContext db;
        private IRepositorioGenerico<Receita, string> repositorioReceita;


        public ReceitaAPL()
        {
            db = new CtrlMoneyDbContext();
            repositorioReceita = new ReceitaReposEntity(db);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Inserir(Receita Receita)
        {

            repositorioReceita.Inserir(Receita);
        }

        //public Receita SelecionarById(string id)
        //{
        //    return repositorioReceita.SelecionarPorId(id);
        //}

        public void Alterar(Receita Receita)
        {

            repositorioReceita.Alterar(Receita);
        }

        public void Deletar(Receita Receita)
        {

            repositorioReceita.Excluir(Receita);
        }
    }
}


   