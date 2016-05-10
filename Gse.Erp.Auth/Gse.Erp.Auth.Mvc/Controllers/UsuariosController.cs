using System;
using System.Net;
using System.Web.Mvc;
#region old GseComunDbContext
// using Gse.Erp.MvcAuth.Models;
#endregion
#region new GseComunDbContext
using Gse.Erp.Auth.Data;
#endregion
using Gse.Erp.Auth.Repository;

namespace Gse.Erp.Auth.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuariosController()
        {
            this._usuarioRepository = new UsuarioRepository(new GseComunDbContext());
        }

        // GET: Usuarios
        [Authorize]
        public ActionResult Index()
        {
            return View(this._usuarioRepository.GetAll());
        }

        // GET: Usuarios/Details/5
        [Authorize]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = id.HasValue ? 
                this._usuarioRepository.GetId((Guid)id) 
                : null;
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View(new Usuario() {              
                FechaAlta = DateTime.Now,
                FechaModificacion = DateTime.Now
            });
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "Id,NombreUsuario,Contrasenya,Email,Nombre,Apellidos,FechaNacimiento,FechaAlta,FechaBaja,FechaModificacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                this._usuarioRepository.Add(usuario);
                this._usuarioRepository.Save();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = id.HasValue ? 
                this._usuarioRepository.GetId((Guid)id) 
                : null;
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "Id,NombreUsuario,Contrasenya,Email,Nombre,Apellidos,FechaNacimiento,FechaAlta,FechaBaja,FechaModificacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                this._usuarioRepository.Update(usuario);
                this._usuarioRepository.Save();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = id.HasValue ? 
                this._usuarioRepository.GetId((Guid)id) 
                : null;
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this._usuarioRepository.Delete(id);
            this._usuarioRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._usuarioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
