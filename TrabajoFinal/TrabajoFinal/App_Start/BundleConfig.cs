using System.Web;
using System.Web.Optimization;

namespace TrabajoFinal
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                     "~/Content/css/bootstrap.min.css",
                     "~/Content/css/bootstrap-datepicker.css",
                     "~/Content/css/daterangepicker.css",
                     "~/Content/css/core.css",
                     "~/Content/css/components.css",
                     "~/Content/css/icons.css",
                     "~/Content/css/pages.css",
                     "~/Content/css/responsive.css",
                     "~/Content/js/modernizr.min.js",
                     "~/Content/css/select2.css",
                     "~/Content/css/custom-style.css",
                     "~/Content/css/sweetalert.css",
                     "~/Content/plugins/summernote/summernote.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/jquery-ui.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/detect.js",
                      "~/Content/js/fastclick.js",
                      "~/Content/js/jquery.slimscroll.js",
                      "~/Content/js/jquery.blockUI.js",
                      "~/Content/js/waves.js",
                      "~/Content/js/wow.min.js",
                      "~/Content/js/jquery.nicescroll.js",
                      "~/Content/js/jquery.scrollTo.min.js",
                      "~/Content/plugins/counterup/jquery.counterup.min.js",
                      "~/Content/js/jscolor.js",
                      "~/Content/js/bootstrap-datepicker.min.js",
                      "~/Content/js/bootstrap-datepicker.es.min.js",
                      "~/Content/js/jquery.core.js",
                      "~/Scripts/jquery.validate.js",
                      "~/Content/jquery.validate.unobtrusive.js",
                      "~/Scripts/jquery.unobtrusive-ajax.js",
                      "~/Content/js/select2.js",
                      "~/Content/js/sweetalert.min.js",
                      "~/Content/plugins/codemirror/js/codemirror.js",
                      "~/Content/plugins/codemirror/js/sql.js",
                      "~/Content/plugins/codemirror/js/sql-hint.js",
                      "~/Content/plugins/summernote/summernote.min.js"
                        ));
        }
    }
}
