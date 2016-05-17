using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gse.Erp.Auth.Mvc.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView(); //View();
        }

        [AllowAnonymous]
        public PartialViewResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView(); //return View();
        }

        [AllowAnonymous]
        public PartialViewResult Address()
        {
            return PartialView();
        }
    }
}