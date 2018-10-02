namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Set_Usuario_Login_Unique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("public.pessoa_usuario", "login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("public.pessoa_usuario", new[] { "login" });
        }
    }
}
