namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_final : DbMigration
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
                        dia_fechamento = c.Int(nullable: false),
                        dia_vencimento = c.Int(nullable: false),
                        numero = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                        PessoaId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.pessoa_usuario", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "public.pessoa_usuario",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        nome = c.String(nullable: false, maxLength: 150),
                        cpf = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        data_nasc = c.DateTime(nullable: false),
                        login = c.String(nullable: false, maxLength: 150),
                        senha = c.String(nullable: false, maxLength: 128),
                        data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.login, unique: true);
            
            CreateTable(
                "public.receita",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fixo = c.Boolean(nullable: false),
                        data_recebimento = c.DateTime(nullable: false),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nome = c.String(nullable: false, maxLength: 160),
                        categoria = c.Int(nullable: false),
                        PessoaId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.pessoa_usuario", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "public.pessoa_cartao",
                c => new
                    {
                        fk_pessoa_usuario = c.String(nullable: false, maxLength: 128),
                        fk_cartao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.fk_pessoa_usuario, t.fk_cartao })
                .ForeignKey("public.pessoa_usuario", t => t.fk_pessoa_usuario, cascadeDelete: true)
                .ForeignKey("public.cartao", t => t.fk_cartao, cascadeDelete: true)
                .Index(t => t.fk_pessoa_usuario)
                .Index(t => t.fk_cartao);
            
            CreateTable(
                "public.parcelamento",
                c => new
                    {
                        id = c.Int(nullable: false),
                        num_parcelas = c.Short(nullable: false),
                        CartaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.despesa", t => t.id)
                .ForeignKey("public.cartao", t => t.CartaoId, cascadeDelete: true)
                .Index(t => t.id)
                .Index(t => t.CartaoId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.sem_parcelamento", "id", "public.despesa");
            DropForeignKey("public.parcelamento", "CartaoId", "public.cartao");
            DropForeignKey("public.parcelamento", "id", "public.despesa");
            DropForeignKey("public.receita", "PessoaId", "public.pessoa_usuario");
            DropForeignKey("public.despesa", "PessoaId", "public.pessoa_usuario");
            DropForeignKey("public.pessoa_cartao", "fk_cartao", "public.cartao");
            DropForeignKey("public.pessoa_cartao", "fk_pessoa_usuario", "public.pessoa_usuario");
            DropIndex("public.sem_parcelamento", new[] { "id" });
            DropIndex("public.parcelamento", new[] { "CartaoId" });
            DropIndex("public.parcelamento", new[] { "id" });
            DropIndex("public.pessoa_cartao", new[] { "fk_cartao" });
            DropIndex("public.pessoa_cartao", new[] { "fk_pessoa_usuario" });
            DropIndex("public.receita", new[] { "PessoaId" });
            DropIndex("public.pessoa_usuario", new[] { "login" });
            DropIndex("public.despesa", new[] { "PessoaId" });
            DropTable("public.sem_parcelamento");
            DropTable("public.parcelamento");
            DropTable("public.pessoa_cartao");
            DropTable("public.receita");
            DropTable("public.pessoa_usuario");
            DropTable("public.despesa");
            DropTable("public.cartao");
        }
    }
}
