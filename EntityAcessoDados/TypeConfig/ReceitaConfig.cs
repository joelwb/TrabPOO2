using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.TypeConfig
{
    class ReceitaConfig : GenericConfig<Receita>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(160)
                .HasColumnName("nome");

            Property(p => p.Valor)
                .IsRequired()
                .HasColumnName("valor");

            Property(p => p.DataRecebimento)
                .IsRequired()
                .HasColumnName("data_recebimento");

            Property(p => p.Fixo)
                .IsRequired()
                .HasColumnName("fixo");

            Property(p => p.Categoria)
                .IsRequired()
                .HasColumnName("categoria");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasRequired(p => p.Pessoa);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("receita");
        }
    }
}
