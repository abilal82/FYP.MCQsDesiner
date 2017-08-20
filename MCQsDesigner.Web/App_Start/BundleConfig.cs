using System.Web;
using System.Web.Optimization;

namespace MCQsDesigner.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/datatables/jquery.dataTables.js",
                       "~/Scripts/datatables/dataTables.bootstrap.js",
                       "~/Scripts/toastr.js",
                       "~/Scripts/DatePicker/bootstrap-datetimepicker.js",
                        "~/Scripts//DatePicker/bootstrap-datetimepicker.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

           

            bundles.Add(new StyleBundle("~/ContentDasboard/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap/bootstrap-datetimepicker.min.css",
                       "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/sb-admin.css",
                      "~/Content/toastr.css"
                     ));
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                "~/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css"
              
                     ));

        }
    }
}
