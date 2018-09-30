namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables_Pessoa_Usuario_Cartao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.cartao",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        limite = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dia_fechamento = c.DateTime(nullable: false),
                        dia_vencimento = c.DateTime(nullable: false),
                        numero = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.pessoa_usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 150),
                        cpf = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        data_nasc = c.DateTime(nullable: false),
                        login = c.String(nullable: false, maxLength: 150),
                        senha = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.pessoa_cartao",
                c => new
                    {
                        fk_pessoa_usuario = c.Int(nullable: false),
                        fk_cartao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.fk_pessoa_usuario, t.fk_cartao })
                .ForeignKey("public.pessoa_usuario", t => t.fk_pessoa_usuario, cascadeDelete: true)
                .ForeignKey("public.cartao", t => t.fk_cartao, cascadeDelete: true)
                .Index(t => t.fk_pessoa_usuario)
                .Index(t => t.fk_cartao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.pessoa_cartao", "fk_cartao", "public.cartao");
            DropForeignKey("public.pessoa_cartao", "fk_pessoa_usuario", "public.pessoa_usuario");
            DropIndex("public.pessoa_cartao", new[] { "fk_cartao" });
            DropIndex("public.pessoa_cartao", new[] { "fk_pessoa_usuario" });
            DropTable("public.pessoa_cartao");
            DropTable("public.pessoa_usuario");
            DropTable("public.cartao");
        }
    }
}
