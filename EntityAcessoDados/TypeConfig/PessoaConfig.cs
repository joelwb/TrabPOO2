﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.TypeConfig
{
    class PessoaConfig : GenericConfig<Pessoa>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .HasMaxLength(128)
                .HasColumnName("id");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("nome");

            Property(p => p.CPF)
                .IsRequired()
                .HasColumnName("cpf")
                .HasMaxLength(11)
                .IsFixedLength();

            Property(p => p.DataNasc)
                .IsRequired()
                .HasColumnName("data_nasc");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasRequired(p => p.Usuario);

            HasMany(p => p.Cartoes)
                .WithMany(c => c.Pessoas)
                .Map(pc =>
                {
                    pc.MapLeftKey("fk_pessoa_usuario");
                    pc.MapRightKey("fk_cartao");
                    pc.ToTable("pessoa_cartao");
                });

            HasMany(p => p.Despesas)
                .WithRequired(p => p.Pessoa)
                .HasForeignKey(p => p.PessoaId);

            HasMany(p => p.Receitas)
                .WithRequired(p => p.Pessoa)
                .HasForeignKey(p => p.PessoaId);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("pessoa_usuario");
            
        }
    }
}
