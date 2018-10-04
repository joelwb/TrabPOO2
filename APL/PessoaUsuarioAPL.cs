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
        private IRepositorioGenerico<Usuario, string> repositorioPessoaUsuario;

        public PessoaUsuarioAPL()
        {
            db = new CtrlMoneyDbContext();
            repositorioPessoaUsuario = new PessoaUsuarioReposEntity(db);
        }

        public void Inserir(Pessoa pessoa, Usuario usuario)
        {
            usuario.Pessoa = pessoa;
            repositorioPessoaUsuario.Inserir(usuario);
        }


    }
}
