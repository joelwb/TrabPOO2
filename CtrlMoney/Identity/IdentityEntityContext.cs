using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CtrlMoney.Identity
{
    public class IdentityEntityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityEntityContext()
            : base("CtrlMoney")
        {
        }

        //Configurar para funcionar no schema public do postgres
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<IdentityUser>().HasKey(p => p.Id);
            modelBuilder.Entity<IdentityRole>().HasKey(p => p.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey(p => p.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(p => new { p.RoleId, p.UserId });
        }*/
    }
}