namespace Gse.Erp.MvcAuth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201605091007429_UpdateUsuarioFechaNacimiento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "FechaNacimiento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "FechaNacimiento", c => c.DateTime(nullable: false));
        }
    }
}
