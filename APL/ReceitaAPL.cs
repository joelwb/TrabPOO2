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

        public List<Receita> Listar(string pessoaId, DateTime inicioMes, DateTime finalMes)
        {
            return repositorioReceita.ListarHistorico(pessoaId, inicioMes, finalMes);
        }

        public void GetAllReceitasMes(DateTime data)
        {
            AbstractClassCategoriaReceita receitaSalario = new ReceitaSalario();
            AbstractClassCategoriaReceita receitaVendas = new ReceitaVenda();
            AbstractClassCategoriaReceita receitaPensao = new ReceitaPensao();
            AbstractClassCategoriaReceita receitaOutros = new ReceitaOutros();

            receitaSalario.SetNext(receitaVendas);
            receitaVendas.SetNext(receitaPensao);
            receitaPensao.SetNext(receitaOutros);

            var valorSoma = 0M;
            receitaSalario.EfetuarCalculo(valorSoma, data);
        }
    }
}


   