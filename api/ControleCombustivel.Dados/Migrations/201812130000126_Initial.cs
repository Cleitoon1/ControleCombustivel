namespace ControleCombustivel.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abastecimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Quantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdVeiculo = c.Int(nullable: false),
                        IdPosto = c.Int(nullable: false),
                        IdCompetencia = c.Int(nullable: false),
                        IdTipoCombustivel = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competencia", t => t.IdCompetencia)
                .ForeignKey("dbo.TipoCombustivel", t => t.IdTipoCombustivel)
                .ForeignKey("dbo.Posto", t => t.IdPosto)
                .ForeignKey("dbo.Veiculo", t => t.IdVeiculo)
                .Index(t => t.IdVeiculo)
                .Index(t => t.IdPosto)
                .Index(t => t.IdCompetencia)
                .Index(t => t.IdTipoCombustivel);
            
            CreateTable(
                "dbo.Competencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCompleto = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false),
                        Placa = c.String(nullable: false),
                        Fabricante = c.String(nullable: false),
                        AnoFabricacao = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        Principal = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.TipoCombustivel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        NomeMedida = c.String(nullable: false),
                        NomeMedidaPlural = c.String(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cnpj = c.String(),
                        Lat = c.Long(nullable: false),
                        Long = c.Long(nullable: false),
                        Cep = c.String(),
                        Rua = c.String(),
                        Numero = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VeiculosTiposCombustiveis",
                c => new
                    {
                        VeiculoId = c.Int(nullable: false),
                        TipoCombustivelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VeiculoId, t.TipoCombustivelId })
                .ForeignKey("dbo.TipoCombustivel", t => t.VeiculoId)
                .ForeignKey("dbo.Veiculo", t => t.TipoCombustivelId)
                .Index(t => t.VeiculoId)
                .Index(t => t.TipoCombustivelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abastecimento", "IdVeiculo", "dbo.Veiculo");
            DropForeignKey("dbo.Abastecimento", "IdPosto", "dbo.Posto");
            DropForeignKey("dbo.Veiculo", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.VeiculosTiposCombustiveis", "TipoCombustivelId", "dbo.Veiculo");
            DropForeignKey("dbo.VeiculosTiposCombustiveis", "VeiculoId", "dbo.TipoCombustivel");
            DropForeignKey("dbo.Abastecimento", "IdTipoCombustivel", "dbo.TipoCombustivel");
            DropForeignKey("dbo.Competencia", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Abastecimento", "IdCompetencia", "dbo.Competencia");
            DropIndex("dbo.VeiculosTiposCombustiveis", new[] { "TipoCombustivelId" });
            DropIndex("dbo.VeiculosTiposCombustiveis", new[] { "VeiculoId" });
            DropIndex("dbo.Veiculo", new[] { "IdUsuario" });
            DropIndex("dbo.Competencia", new[] { "IdUsuario" });
            DropIndex("dbo.Abastecimento", new[] { "IdTipoCombustivel" });
            DropIndex("dbo.Abastecimento", new[] { "IdCompetencia" });
            DropIndex("dbo.Abastecimento", new[] { "IdPosto" });
            DropIndex("dbo.Abastecimento", new[] { "IdVeiculo" });
            DropTable("dbo.VeiculosTiposCombustiveis");
            DropTable("dbo.Posto");
            DropTable("dbo.TipoCombustivel");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Usuario");
            DropTable("dbo.Competencia");
            DropTable("dbo.Abastecimento");
        }
    }
}
