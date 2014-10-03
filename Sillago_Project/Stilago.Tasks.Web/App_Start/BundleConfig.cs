using System.Web.Optimization;

namespace Stilago.Tasks.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/tableStyle.css",
                      "~/Content/syndication.css",
                      "~/Content/uploadfile.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jQueryDatatables").Include(
                "~/Scripts/DataTables-1.10.2/jquery.dataTables.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/jQueryDatatablesStyle").Include(
                "~/Content/DataTables-1.10.2/css/jquery.dataTables.css"
                ));



            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
