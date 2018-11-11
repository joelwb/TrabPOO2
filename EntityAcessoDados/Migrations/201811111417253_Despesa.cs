namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Despesa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.despesa", name: "Pessoa_Id", newName: "PessoaId");
            RenameIndex(table: "public.despesa", name: "IX_Pessoa_Id", newName: "IX_PessoaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "public.despesa", name: "IX_PessoaId", newName: "IX_Pessoa_Id");
            RenameColumn(table: "public.despesa", name: "PessoaId", newName: "Pessoa_Id");
        }
    }
}
