using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.Repositorio
{
    class PessoaUsuarioReposEntity : RepositorioGenericoEntity<PessoaUsuarioReposEntity, string>
    {
        public PessoaUsuarioReposEntity(DbContext contexto) : base(contexto)
        {
        }

    }
}
