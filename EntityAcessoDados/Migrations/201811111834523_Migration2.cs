namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.parcelamento", name: "Cartao_Id", newName: "CartaoId");
            RenameIndex(table: "public.parcelamento", name: "IX_Cartao_Id", newName: "IX_CartaoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "public.parcelamento", name: "IX_CartaoId", newName: "IX_Cartao_Id");
            RenameColumn(table: "public.parcelamento", name: "CartaoId", newName: "Cartao_Id");
        }
    }
}
