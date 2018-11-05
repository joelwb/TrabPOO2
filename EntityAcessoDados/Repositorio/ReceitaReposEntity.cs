using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityAcessoDados.Repositorio
{
    public class ReceitaReposEntity: RepositorioGenericoEntity<Receita, string>
    {
        public ReceitaReposEntity(DbContext contexto) : base(contexto)
        {
        }

        public override void Inserir(Receita entidade)
        {
            _contexto.Set<Receita>().Add(entidade);
            _contexto.SaveChanges();
        }

        //public override Despesa SelecionarPorId(string id)
        //{
        //    return _contexto.Set<Despesa>().Include(p => p.Pessoa).SingleOrDefault(p => p.Id == id);
        //}

        public override void Alterar(Receita entidade)
        {
            _contexto.Set<Receita>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.Entry(entidade.Pessoa).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public override void Excluir(Receita entidade)
        {
            _contexto.Set<Receita>().Attach(entidade);
            _contexto.Entry(entidade.Pessoa).State = EntityState.Deleted;
            _contexto.Entry(entidade).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
