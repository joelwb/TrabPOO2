using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.Repositorio
{
    public class CartaoReposEntity : RepositorioGenericoEntity<Cartao, string>
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

        public override Cartao SelecionarPorId(string id)
        {
            return base.SelecionarPorId(id);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
