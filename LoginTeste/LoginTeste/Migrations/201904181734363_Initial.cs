namespace LoginTeste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        PaisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoId)
                .ForeignKey("dbo.Pais", t => t.PaisId, cascadeDelete: true)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaisId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PaisId);
            
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        EspecialidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EspecialidadeId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Endereco = c.String(maxLength: 100),
                        Telefone = c.String(maxLength: 100),
                        EspecialidadeId = c.Int(nullable: false),
                        CidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoId)
                .ForeignKey("dbo.Cidades", t => t.CidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Especialidades", t => t.EspecialidadeId, cascadeDelete: true)
                .Index(t => t.EspecialidadeId)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100),
                        login = c.String(nullable: false, maxLength: 100),
                        senha = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "EspecialidadeId", "dbo.Especialidades");
            DropForeignKey("dbo.Medicos", "CidadeId", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Estadoes", "PaisId", "dbo.Pais");
            DropIndex("dbo.Medicos", new[] { "CidadeId" });
            DropIndex("dbo.Medicos", new[] { "EspecialidadeId" });
            DropIndex("dbo.Estadoes", new[] { "PaisId" });
            DropIndex("dbo.Cidades", new[] { "EstadoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Medicos");
            DropTable("dbo.Especialidades");
            DropTable("dbo.Pais");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Cidades");
        }
    }
}
