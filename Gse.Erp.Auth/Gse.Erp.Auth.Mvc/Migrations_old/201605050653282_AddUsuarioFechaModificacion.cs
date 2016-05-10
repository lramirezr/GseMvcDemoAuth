namespace Gse.Erp.MvcAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsuarioFechaModificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "FechaModificacion", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usarios", "FechaModificacion");
        }
    }
}
