namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Config_Despesa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.despesa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        data_compra = c.DateTime(nullable: false),
                        fixo = c.Boolean(nullable: false),
                        nome = c.String(nullable: false, maxLength: 160),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoria = c.Int(nullable: false),
                        forma_pag = c.Int(nullable: false),
                        Pessoa_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.pessoa_usuario", t => t.Pessoa_Id, cascadeDelete: true)
                .Index(t => t.Pessoa_Id);
            
            CreateTable(
                "public.parcelamento",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Cartao_Id = c.Int(nullable: false),
                        num_parcelas = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.despesa", t => t.id)
                .ForeignKey("public.cartao", t => t.Cartao_Id, cascadeDelete: true)
                .Index(t => t.id)
                .Index(t => t.Cartao_Id);
            
            CreateTable(
                "public.sem_parcelamento",
                c => new
                    {
                        id = c.Int(nullable: false),
                        data_pag = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.despesa", t => t.id)
                .Index(t => t.id);
            
            DropColumn("public.receita", "PessoaId");
        }
        
        public override void Down()
        {
            AddColumn("public.receita", "PessoaId", c => c.Int(nullable: false));
            DropForeignKey("public.sem_parcelamento", "id", "public.despesa");
            DropForeignKey("public.parcelamento", "Cartao_Id", "public.cartao");
            DropForeignKey("public.parcelamento", "id", "public.despesa");
            DropForeignKey("public.despesa", "Pessoa_Id", "public.pessoa_usuario");
            DropIndex("public.sem_parcelamento", new[] { "id" });
            DropIndex("public.parcelamento", new[] { "Cartao_Id" });
            DropIndex("public.parcelamento", new[] { "id" });
            DropIndex("public.despesa", new[] { "Pessoa_Id" });
            DropTable("public.sem_parcelamento");
            DropTable("public.parcelamento");
            DropTable("public.despesa");
        }
    }
}
