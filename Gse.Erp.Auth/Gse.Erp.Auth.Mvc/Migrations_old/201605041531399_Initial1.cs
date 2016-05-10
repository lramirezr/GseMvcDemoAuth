namespace Gse.Erp.MvcAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    NombreUsuario = c.String(),
                    Contrasenya = c.Binary(),
                    Email = c.String(),
                    Nombre = c.String(),
                    Apellidos = c.String(),
                    FechaNacimiento = c.DateTime(nullable: false),
                    FechaAlta = c.DateTime(nullable: false),
                    FechaBaja = c.DateTime(nullable: false),
                    //FechaModificacion = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
