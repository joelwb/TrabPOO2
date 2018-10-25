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
    public class CartaoAPL : IAPLGenerica
    {
        private CtrlMoneyDbContext db;
        private IRepositorioGenerico<Cartao, int> repositorioCartao;

        public CartaoAPL()
        {
            db = new CtrlMoneyDbContext();
            repositorioCartao = new CartaoReposEntity(db);
        }

        public List<Cartao> SelecionarPorPessoa(String id_pessoa)
        {
            List<Cartao> cartoes = ((CartaoReposEntity)repositorioCartao).SelecionarPorPessoa(id_pessoa);

            return cartoes;
        }

        public void Inserir(Cartao cartao)
        {
            repositorioCartao.Inserir(cartao);
        }

        public void Alterar(Cartao cartao)
        {
            repositorioCartao.Alterar(cartao);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
