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
            _contexto.Set<Cartao>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
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
            _contexto.Set<Cartao>().Add(entidade);
            _contexto.SaveChanges();
        }

        public override List<Cartao> Selecionar()
        {
            return base.Selecionar();
        }
        
        public override Cartao SelecionarPorId(int id)
        {
            return _contexto.Set<Cartao>().SingleOrDefault(c => c.Id == id);
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
                               c = cartao
                           } ;
            List<Cartao> novo = new List<Cartao>();
            foreach (var item in conteudo){
                novo.Add(item.c);
            }
            return novo;
        }

        public void ExcluirPessoa(Cartao cartao, Pessoa pessoa)
        {
            _contexto.Entry(cartao).Collection("Pessoas").Load();
            foreach (Pessoa item in cartao.Pessoas)
            {
                if (item.Id == pessoa.Id)
                {
                    pessoa = item;
                    break;
                }
            }
            cartao.Pessoas.Remove(pessoa);
            _contexto.SaveChanges();
        }
    }
}
