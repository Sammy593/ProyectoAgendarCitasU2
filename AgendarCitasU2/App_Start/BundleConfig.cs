using System.Web;
using System.Web.Optimization;

namespace AgendarCitasU2
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/fastclick.js",
                      "~/Scripts/nprogress.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/nprogress.css",
                      "~/Content/animate.min.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/sweetalert/sweet-alert.css",
                      "~/Content/custom.css",
                      "~/Content/site.css")); ;
        }
    }
}
