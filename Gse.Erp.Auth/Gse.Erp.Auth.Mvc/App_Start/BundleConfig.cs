using System.Web.Optimization;

namespace Gse.Erp.Auth.Mvc
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Shared/_Layout.css"));

            /* css ~ GseContent */
            bundles.Add(new StyleBundle("~/GseContent/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/assets/css/ie10-viewport-bug-workaround.css",
                "~/Content/Shared/cover.css"));

            /* javascript ~ GseAssets */
            bundles.Add(new ScriptBundle("~/bundles/assets-responsive").Include(
                        "~/Scripts/assets/js/ie8-responsive-file-warning.js"));

            bundles.Add(new ScriptBundle("~/bundles/assets-emulation").Include(
                        "~/Scripts/assets/js/ie-emulation-modes-warning.js"));

            bundles.Add(new ScriptBundle("~/bundles/assets-viewport").Include(
                        "~/Scripts/assets/js/ie10-viewport-bug-workaround.js"));

            /* javascript ~ GseBootstrap */
            bundles.Add(new ScriptBundle("~/bundles/GseBootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));
        }
    }
}
