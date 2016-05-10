#region old Gse.Erp.MvcAuth.Models
using Gse.Erp.MvcAuth.Models;
#endregion
using Gse.Erp.MvcAuth.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace Gse.Erp.MvcAuth.Migrations
{
    // internal sealed class Configuration : DbMigrationsConfiguration<Gse.Erp.MvcAuth.Models.ApplicationDbContext>
    #region old GseComunDbContext
    // internal sealed class Configuration : DbMigrationsConfiguration<Gse.Erp.MvcAuth.Models.GseComunDbContext>
    #endregion
    internal sealed class Configuration : DbMigrationsConfiguration<Gse.Erp.MvcAuth.Data.GseComunDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        #region old GseComunDbContext
        // bool AddUserAndRole(Gse.Erp.MvcAuth.Models.GseComunDbContext context)
        #endregion
        bool AddUserAndRole(Gse.Erp.MvcAuth.Data.GseComunDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        #region old GseComunDbContext
        // protected override void Seed(Gse.Erp.MvcAuth.Models.GseComunDbContext context)
        #endregion
        protected override void Seed(Gse.Erp.MvcAuth.Data.GseComunDbContext context)
        {
            AddUserAndRole(context);
            #region create method contacts in contacts table
            //context.Contacts.AddOrUpdate(p => p.Name,
            //   new Contact
            //   {
            //       Name = "Debra Garcia",
            //       Address = "1234 Main St",
            //       City = "Redmond",
            //       State = "WA",
            //       Zip = "10999",
            //       Email = "debra@example.com",
            //   },
            //    new Contact
            //    {
            //        Name = "Thorsten Weinrich",
            //        Address = "5678 1st Ave W",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "thorsten@example.com",
            //    },
            //    new Contact
            //    {
            //        Name = "Yuhong Li",
            //        Address = "9012 State st",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "yuhong@example.com",
            //    },
            //    new Contact
            //    {
            //        Name = "Jon Orton",
            //        Address = "3456 Maple St",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "jon@example.com",
            //    },
            //    new Contact
            //    {
            //        Name = "Diliana Alexieva-Bosseva",
            //        Address = "7890 2nd Ave E",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "diliana@example.com",
            //    }
            //    );
            #endregion
        }
    }
}
