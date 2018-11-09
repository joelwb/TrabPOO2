namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.pessoa_usuario", name: "DataCadastro", newName: "data_cadastro");
        }
        
        public override void Down()
        {
            RenameColumn(table: "public.pessoa_usuario", name: "data_cadastro", newName: "DataCadastro");
        }
    }
}
