﻿using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ReceitaPensao : AbstractClassCategoriaReceita
    {
        public ReceitaPensao(string id)
        {
            IdUser = id;
        }
        private string IdUser;
        private readonly IRepositorioGenerico<Receita, int> _repositorioReceita;
        protected CategoriaReceita categoria = CategoriaReceita.Pensao;

        protected override decimal Somar(decimal valor, DateTime data)
        {
            var ReceitaMes = _repositorioReceita.Selecionar().Where(x => x.Categoria.Equals(categoria) && x.PessoaId.Equals(IdUser)).Select(x => x.Valor).Sum();
            var valorSomado = ReceitaMes + valor;
            return valorSomado;
        }
    }
}
