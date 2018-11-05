using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityAcessoDados.Repositorio
{
    public class DespesaReposEntity : RepositorioGenericoEntity<Despesa, string>
    { 
     public DespesaReposEntity(DbContext contexto) : base(contexto)
    {
    }

    public override void Inserir(Despesa entidade)
    {
        _contexto.Set<Despesa>().Add(entidade);
        _contexto.SaveChanges();
    }

    //public override Despesa SelecionarPorId(string id)
    //{
    //    return _contexto.Set<Despesa>().Include(p => p.Pessoa).SingleOrDefault(p => p.Id == id);
    //}

    public override void Alterar(Despesa entidade)
    {
        _contexto.Set<Despesa>().Attach(entidade);
        _contexto.Entry(entidade).State = EntityState.Modified;
        _contexto.Entry(entidade.Pessoa).State = EntityState.Modified;
        _contexto.SaveChanges();
    }

    public override void Excluir(Despesa entidade)
    {
        _contexto.Set<Despesa>().Attach(entidade);
        _contexto.Entry(entidade.Pessoa).State = EntityState.Deleted;
        _contexto.Entry(entidade).State = EntityState.Deleted;
        _contexto.SaveChanges();
    }
}
}
