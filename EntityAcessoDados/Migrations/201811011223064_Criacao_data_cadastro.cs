namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_data_cadastro : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.pessoa_usuario", "DataCadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.pessoa_usuario", "DataCadastro");
        }
    }
}
