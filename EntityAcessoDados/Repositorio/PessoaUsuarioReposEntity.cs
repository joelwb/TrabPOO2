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
            return _contexto.Set<Usuario>().Include(p => p.Pessoa).SingleOrDefault(p => p.Id == id);
        }
    }
}
