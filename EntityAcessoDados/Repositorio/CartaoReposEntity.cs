using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.Repositorio
{
    public class CartaoReposEntity : RepositorioGenericoEntity<Cartao, int>
    {
        public CartaoReposEntity(DbContext contexto) : base(contexto)
        {
        }

        public override void Alterar(Cartao entidade)
        {
            base.Alterar(entidade);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void Excluir(Cartao entidade)
        {
            base.Excluir(entidade);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Inserir(Cartao entidade)
        {
            base.Inserir(entidade);
        }

        public override List<Cartao> Selecionar()
        {
            return base.Selecionar();
        }

        public override Cartao SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }

        public override string ToString()
        {
            return base.ToString();
        }



        public List<Cartao> SelecionarPorPessoa(string id_pessoa)
        {
            var conteudo = from pessoa in _contexto.Set<Pessoa>()
                           from cartao in pessoa.Cartoes
                           where pessoa.Id == id_pessoa
                           select new
                           {
                               p = pessoa,
                               c = cartao
                           } ;
            List<Cartao> novo = new List<Cartao>();
            foreach (var item in conteudo){
                novo.Add(item.c);
            }
            return novo;
        }
    }
}
