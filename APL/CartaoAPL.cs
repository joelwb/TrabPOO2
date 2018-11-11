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

        public Cartao SelecionarPorId(int id)
        {
            return repositorioCartao.SelecionarPorId(id);
        }

        public Cartao SelecionarPorNumero(long numero)
        {
            return ((CartaoReposEntity) repositorioCartao).SelecionarPorNumero(numero);
        }

        public void Inserir(Cartao cartao)
        {
            repositorioCartao.Inserir(cartao);
        }

        public void InserirPessoa(Cartao cartao, Pessoa pessoa)
        {
            ((CartaoReposEntity)repositorioCartao).InserirPessoa(cartao,pessoa);
        }

        public void Alterar(Cartao cartao)
        {
            repositorioCartao.Alterar(cartao);
        }

        public void Excluir(Cartao cartao)
        {
            repositorioCartao.Excluir(cartao);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
