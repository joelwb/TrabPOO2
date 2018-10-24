namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Config_Receita : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.receita",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fixo = c.Boolean(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        data_recebimento = c.DateTime(nullable: false),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nome = c.String(nullable: false, maxLength: 160),
                        categoria = c.Int(nullable: false),
                        Pessoa_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.pessoa_usuario", t => t.Pessoa_Id, cascadeDelete: true)
                .Index(t => t.Pessoa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.receita", "Pessoa_Id", "public.pessoa_usuario");
            DropIndex("public.receita", new[] { "Pessoa_Id" });
            DropTable("public.receita");
        }
    }
}
