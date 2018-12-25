namespace ControleCombustivel.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionando_tipo_usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 120, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuario", "IdTipoUsuario", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "IdTipoUsuario");
            AddForeignKey("dbo.Usuario", "IdTipoUsuario", "dbo.TipoUsuario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "IdTipoUsuario", "dbo.TipoUsuario");
            DropIndex("dbo.Usuario", new[] { "IdTipoUsuario" });
            DropColumn("dbo.Usuario", "IdTipoUsuario");
            DropTable("dbo.TipoUsuario");
        }
    }
}
