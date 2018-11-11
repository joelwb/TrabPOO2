namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class receita : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.receita", name: "Pessoa_Id", newName: "PessoaId");
            RenameIndex(table: "public.receita", name: "IX_Pessoa_Id", newName: "IX_PessoaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "public.receita", name: "IX_PessoaId", newName: "IX_Pessoa_Id");
            RenameColumn(table: "public.receita", name: "PessoaId", newName: "Pessoa_Id");
        }
    }
}
