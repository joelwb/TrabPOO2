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
    public class PessoaUsuarioAPL
    {
        private CtrlMoneyDbContext db;
        private IRepositorioGenerico<Usuario, string> repositorioUsuario;
        private IRepositorioGenerico<Pessoa, string> repositorioPessoa;

        public PessoaUsuarioAPL()
        {
            db = new CtrlMoneyDbContext();
            repositorioUsuario = new RepositorioGenericoEntity<Usuario, string>(db);
            repositorioPessoa = new RepositorioGenericoEntity<Pessoa, string>(db);
        }

        public void Inserir(Pessoa pessoa, Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.Pessoas.Add(pessoa);
            db.SaveChanges();
        }
    }
}
