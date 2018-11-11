using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.TypeConfig
{
    class CartaoConfig : GenericConfig<Cartao>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            Property(p => p.Numero)
                .IsRequired()
                .HasColumnName("numero");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasMaxLength(50);

            Property(p => p.Limite)
                .IsRequired()
                .HasColumnName("limite");

            Property(p => p.DiaFechamento)
                .IsRequired()
                .HasColumnName("dia_fechamento");

            Property(p => p.DiaVencimento)
                .IsRequired()
                .HasColumnName("dia_vencimento");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasMany(p => p.Parcelamentos)
                .WithRequired(p => p.Cartao)
                .HasForeignKey(p => p.CartaoId);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("cartao");
        }
    }
}
