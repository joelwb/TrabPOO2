namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.pessoa_usuario", "data_cadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.pessoa_usuario", "data_cadastro", c => c.DateTime(nullable: false));
        }
    }
}
