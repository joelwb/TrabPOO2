using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.TypeConfig
{
    class ParcelamentoConfig : GenericConfig<Parcelamento>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.NumParcelas)
                .HasColumnName("num_parcelas")
                .IsRequired();
        }

        protected override void ConfigurarChavePrimaria()
        {
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("parcelamento");
        }
    }
}
