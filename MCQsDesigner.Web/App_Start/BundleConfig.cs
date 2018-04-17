using System.Web;
using System.Web.Optimization;

namespace MCQsDesigner.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // OLD dashBoard Assets
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
           

            

            // Admin LTE DashBoard Assets
            bundles.Add(new ScriptBundle("~/bundles/JavascriptsLib").Include(
                         "~/Content/plugins/jQuery/jquery-2.2.3.min.js",
                         "~/Scripts/FlipClock/flipclock.js",
                         "~/Content/bootstrap/js/bootstrap.min.js",
                         "~/Content/bootbox.min.js",
                         "~/Content/plugins/sparkline/jquery.sparkline.min.js",
                         "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                         "~/Content/plugins/fastclick/fastclick.js",
                         "~/Content/dist/js/app.min.js",
                         "~/Scripts/respond.js",
                         "~/Scripts/datatables/jquery.dataTables.js",
                         "~/Scripts/datatables/dataTables.bootstrap.js",
                         "~/Scripts/toastr.js",
                         "~/Scripts/DatePicker/bootstrap-datetimepicker.js",
                         "~/Scripts/DatePicker/bootstrap-datetimepicker.js",
                         "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"
                       ));

            bundles.Add(new StyleBundle("~/AdminLTEDasboard/css").Include(
                       "~/Content/bootstrap/css/bootstrap.min.css",
                        "~/Scripts/FlipClock/flipclock.css",//FlipClock CSS used in attempting exam
                       "~/Content/dist/css/AdminLTE.min.css",
                       "~/Content/dist/css/skins/skin-blue.min.css",
                       "~/Content/datatables/css/datatables.bootstrap.css",
                       "~/Content/bootstrap/bootstrap-datetimepicker.min.css",
                       "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                        "~/Content/toastr.css"

                     ));
           
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

        }
    }
}
