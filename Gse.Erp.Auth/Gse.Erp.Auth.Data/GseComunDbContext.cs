using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gse.Erp.Auth.Data
{
    public class GseComunDbContext : IdentityDbContext<ApplicationUser>
    {
        public GseComunDbContext()
            : base("DbUserConnection", throwIfV1Schema: false)
        {
        }

        public static GseComunDbContext Create()
        {
            return new GseComunDbContext();
        }

        public System.Data.Entity.DbSet<Gse.Erp.Auth.Data.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<Gse.Erp.Auth.Data.Empresa> Empresas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>()
                .HasOptional(e => e.Usuario)
                .WithMany(u => u.Empresas)
                .HasForeignKey(e => e.UsuarioId);
        }
    }
}
