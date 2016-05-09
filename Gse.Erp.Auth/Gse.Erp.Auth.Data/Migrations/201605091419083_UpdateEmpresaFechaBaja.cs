namespace Gse.Erp.MvcAuth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmpresaFechaBaja : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empresas", "FechaBaja", c => c.DateTime(nullable:true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresas", "FechaBaja", c => c.DateTime(nullable: false));
        }
    }
}
