using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.Repositorio
{
    public class PessoaUsuarioReposEntity : RepositorioGenericoEntity<Usuario, string>
    {
        public PessoaUsuarioReposEntity(DbContext contexto) : base(contexto)
        {
        }

        public override void Inserir(Usuario entidade)
        {
            _contexto.Set<Usuario>().Add(entidade);
            _contexto.SaveChanges();
        }

        public override Usuario SelecionarPorId(string id)
        {
            return _contexto.Set<Usuario>().Include(p => p.Pessoa).Include(p => p.Pessoa.Cartoes).SingleOrDefault(p => p.Id == id);
        }

        public override void Alterar(Usuario entidade)
        {
            _contexto.Set<Usuario>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.Entry(entidade.Pessoa).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public override void Excluir(Usuario entidade)
        {
            _contexto.Set<Usuario>().Attach(entidade);
            _contexto.Entry(entidade.Pessoa).State = EntityState.Deleted;
            _contexto.Entry(entidade).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
