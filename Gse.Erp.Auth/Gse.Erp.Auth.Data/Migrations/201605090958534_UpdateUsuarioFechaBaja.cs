namespace Gse.Erp.Auth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsuarioFechaBaja : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "FechaBaja", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "FechaBaja", c => c.DateTime(nullable: false));
        }
    }
}
