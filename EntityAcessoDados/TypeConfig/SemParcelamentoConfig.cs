using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados.TypeConfig
{
    class SemParcelamentoConfig : GenericConfig<SemParcelamento>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.DataPag)
                .IsRequired()
                .HasColumnName("data_pag");
        }

        protected override void ConfigurarChavePrimaria()
        {
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("sem_parcelamento");
        }
    }
}
