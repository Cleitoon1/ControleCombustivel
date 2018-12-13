namespace ControleCombustivel.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoVarchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abastecimento", "Nome", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Abastecimento", "Descricao", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Competencia", "Nome", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Competencia", "Descricao", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Usuario", "NomeCompleto", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Usuario", "Cpf", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Veiculo", "Modelo", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Veiculo", "Placa", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Veiculo", "Fabricante", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.TipoCombustivel", "Nome", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.TipoCombustivel", "NomeMedida", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.TipoCombustivel", "NomeMedidaPlural", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Nome", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Cnpj", c => c.String(maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Cep", c => c.String(maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Rua", c => c.String(maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Numero", c => c.String(maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Bairro", c => c.String(maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Cidade", c => c.String(maxLength: 120, unicode: false));
            AlterColumn("dbo.Posto", "Estado", c => c.String(maxLength: 120, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posto", "Estado", c => c.String());
            AlterColumn("dbo.Posto", "Cidade", c => c.String());
            AlterColumn("dbo.Posto", "Bairro", c => c.String());
            AlterColumn("dbo.Posto", "Numero", c => c.String());
            AlterColumn("dbo.Posto", "Rua", c => c.String());
            AlterColumn("dbo.Posto", "Cep", c => c.String());
            AlterColumn("dbo.Posto", "Cnpj", c => c.String());
            AlterColumn("dbo.Posto", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.TipoCombustivel", "NomeMedidaPlural", c => c.String(nullable: false));
            AlterColumn("dbo.TipoCombustivel", "NomeMedida", c => c.String(nullable: false));
            AlterColumn("dbo.TipoCombustivel", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Veiculo", "Fabricante", c => c.String(nullable: false));
            AlterColumn("dbo.Veiculo", "Placa", c => c.String(nullable: false));
            AlterColumn("dbo.Veiculo", "Modelo", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Cpf", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "NomeCompleto", c => c.String(nullable: false));
            AlterColumn("dbo.Competencia", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Competencia", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Abastecimento", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Abastecimento", "Nome", c => c.String(nullable: false));
        }
    }
}
