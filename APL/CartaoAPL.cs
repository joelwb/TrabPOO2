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


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
