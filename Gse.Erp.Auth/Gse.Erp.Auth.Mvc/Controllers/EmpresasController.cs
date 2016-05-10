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
    public class EmpresasController : Controller
    {
        private IEmpresaRepository _empresaRepository;
        private IUsuarioRepository _usuarioReporitory;

        public EmpresasController()
        {
            GseComunDbContext db = new GseComunDbContext();

            this._empresaRepository = new EmpresaRepository(db);
            this._usuarioReporitory = new UsuarioRepository(db);
        }

        // GET: Empresas
        [Authorize]
        public ActionResult Index()
        {
            return View(this._empresaRepository.GetAll());
        }

        // GET: Empresas/Details/5
        [Authorize]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = id.HasValue ? 
                this._empresaRepository.GetId((Guid)id) 
                : null;
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(this._usuarioReporitory.GetAll(), "Id", "NombreUsuario");
            return View(new Empresa() { FechaAlta = DateTime.Now, FechaModificacion = DateTime.Now });
        }

        // POST: Empresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "Id,Cif,Nombre,FechaAlta,FechaBaja,FechaModificacion,UsuarioId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.Id = Guid.NewGuid();
                this._empresaRepository.Add(empresa);
                this._empresaRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(this._usuarioReporitory.GetAll(), "Id", "NombreUsuario", empresa.UsuarioId);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = id.HasValue ? 
                this._empresaRepository.GetId((Guid)id) 
                : null;
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(this._usuarioReporitory.GetAll(), "Id", "NombreUsuario", empresa.UsuarioId);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "Id,Cif,Nombre,FechaAlta,FechaBaja,FechaModificacion,UsuarioId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                this._empresaRepository.Update(empresa);
                this._empresaRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(this._usuarioReporitory.GetAll(), "Id", "NombreUsuario", empresa.UsuarioId);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = id.HasValue ? 
                this._empresaRepository.GetId((Guid)id) 
                : null;
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Empresa empresa = this._empresaRepository.GetId(id);
            this._empresaRepository.Delete(id);
            this._empresaRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._empresaRepository.Dispose();
                this._usuarioReporitory.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
