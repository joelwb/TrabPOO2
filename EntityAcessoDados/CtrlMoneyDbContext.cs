using Dominio;
using EntityAcessoDados.TypeConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAcessoDados
{
    public class CtrlMoneyDbContext : DbContext
    {
        public CtrlMoneyDbContext() : base("CtrlMoney")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Parcelamento> Parcelamentos { get; set; }
        public DbSet<SemParcelamento> SemParcelamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Configurations.Add(new PessoaConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new CartaoConfig());
            modelBuilder.Configurations.Add(new ReceitaConfig());
            modelBuilder.Configurations.Add(new DespesaConfig());
            modelBuilder.Configurations.Add(new ParcelamentoConfig());
            modelBuilder.Configurations.Add(new SemParcelamentoConfig());
        }
    }
}
