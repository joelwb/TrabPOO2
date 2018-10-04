namespace EntityAcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Type_Id_Pessoa_Usuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.pessoa_cartao", "fk_pessoa_usuario", "public.pessoa_usuario");
            DropIndex("public.pessoa_cartao", new[] { "fk_pessoa_usuario" });
            DropPrimaryKey("public.pessoa_usuario");
            DropPrimaryKey("public.pessoa_cartao");
            AlterColumn("public.pessoa_usuario", "id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("public.pessoa_cartao", "fk_pessoa_usuario", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("public.pessoa_usuario", "id");
            AddPrimaryKey("public.pessoa_cartao", new[] { "fk_pessoa_usuario", "fk_cartao" });
            CreateIndex("public.pessoa_cartao", "fk_pessoa_usuario");
            AddForeignKey("public.pessoa_cartao", "fk_pessoa_usuario", "public.pessoa_usuario", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.pessoa_cartao", "fk_pessoa_usuario", "public.pessoa_usuario");
            DropIndex("public.pessoa_cartao", new[] { "fk_pessoa_usuario" });
            DropPrimaryKey("public.pessoa_cartao");
            DropPrimaryKey("public.pessoa_usuario");
            AlterColumn("public.pessoa_cartao", "fk_pessoa_usuario", c => c.Int(nullable: false));
            AlterColumn("public.pessoa_usuario", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("public.pessoa_cartao", new[] { "fk_pessoa_usuario", "fk_cartao" });
            AddPrimaryKey("public.pessoa_usuario", "id");
            CreateIndex("public.pessoa_cartao", "fk_pessoa_usuario");
            AddForeignKey("public.pessoa_cartao", "fk_pessoa_usuario", "public.pessoa_usuario", "id", cascadeDelete: true);
        }
    }
}
