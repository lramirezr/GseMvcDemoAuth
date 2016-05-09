using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gse.Erp.MvcAuth.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

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

        public System.Data.Entity.DbSet<Gse.Erp.MvcAuth.Models.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<Gse.Erp.MvcAuth.Models.Empresa> Empresas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>()
                .HasOptional(e => e.Usuario)
                .WithMany(u => u.Empresas)
                .HasForeignKey(e => e.UsuarioId);
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Gse.Erp.MvcAuth.Models.Contact> Contacts { get; set; }
    }
}