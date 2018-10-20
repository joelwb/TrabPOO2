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
        private IRepositorioGenerico<Cartao, string> repositorioCartao;

        public CartaoAPL()
        {
            db = new CtrlMoneyDbContext();
            repositorioCartao = new CartaoReposEntity(db);
        }

        public List<Cartao> listarCartoes(String id_pessoa)
        {
            List<Cartao> cartoes = ((CartaoReposEntity)repositorioCartao).SelecionarPorPessoa(id_pessoa);

            return cartoes;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
