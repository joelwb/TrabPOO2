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
   public class ReceitaAPL : IAPLGenerica
    {
        private CtrlMoneyDbContext db;
        private IRepositorioHistorico<Receita, int> repositorioReceita;


        public ReceitaAPL()
        {
            db = new CtrlMoneyDbContext();
            repositorioReceita = new RepositorioReceitaEntity(db);
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

        public List<Receita> Listar(string pessoaId, int ano, int mes)
        {
            return repositorioReceita.ListarHistorico(pessoaId, ano, mes);
        }

        public void GetAllReceitasMes(DateTime data, string id)
        {
            AbstractClassCategoriaReceita receitaSalario = new ReceitaSalario(id);
            AbstractClassCategoriaReceita receitaVendas = new ReceitaVenda(id);
            AbstractClassCategoriaReceita receitaPensao = new ReceitaPensao(id);
            AbstractClassCategoriaReceita receitaOutros = new ReceitaOutros(id);

            receitaSalario.SetNext(receitaVendas);
            receitaVendas.SetNext(receitaPensao);
            receitaPensao.SetNext(receitaOutros);

            var valorSoma = 0M;
            receitaSalario.EfetuarCalculo(valorSoma, data);
        }
    }
}


   