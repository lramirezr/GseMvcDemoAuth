namespace Gse.Erp.MvcAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpresaClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Cif = c.String(),
                        Nombre = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        UsuarioId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empresas", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Empresas", new[] { "UsuarioId" });
            DropTable("dbo.Empresas");
        }
    }
}
