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
            return _contexto.Set<Cartao>().Include(c => c.Pessoas).SingleOrDefault(c => c.Id == id);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
