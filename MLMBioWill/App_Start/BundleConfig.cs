using System.Web;
using System.Web.Optimization;

namespace MLMBioWill
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/plugin/jquery/jquery-{version}.min.js",
                        "~/Content/plugin/tether/js/tether.min.js",
                        "~/Content/plugin/bootstrap/js/bootstrap.min.js",
                        "~/Content/plugin/detectmobilebrowser/detectmobilebrowser.js",
                        "~/Content/plugin/jscrollpane/jquery.mousewheel.js",
                        "~/Content/plugin/jscrollpane/mwheelIntent.js",
                        "~/Content/plugin/jscrollpane/jquery.jscrollpane.min.js",
                        "~/Content/plugin/jquery-fullscreen-plugin/jquery.fullscreen-min.js",
                        "~/Content/plugin/waves/waves.min.js",
                        "~/Content/plugin/switchery/dist/switchery.min.js",
                        "~/Content/plugin/bootstrap-maxlength/src/bootstrap-maxlength.js",
                        "~/Content/plugin/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js",
                        "~/Content/plugin/multi-select/js/jquery.multi-select.js",
                        "~/Content/plugin/dropify/dist/js/dropify.min.js",
                        "~/Content/plugin/flot/jquery.flot.min.js",
                        "~/Content/plugin/flot/jquery.flot.resize.min.js",
                        "~/Content/plugin/flot.tooltip/js/jquery.flot.tooltip.min.js",
                        "~/Content/plugin/sparkline/jquery.sparkline.min.js",
                        "~/Content/plugin/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                        "~/Content/plugin/clockpicker/dist/jquery-clockpicker.min.js",
                        "~/Content/plugin/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                        "~/Content/plugin/moment/moment.js",
                        "~/Content/plugin/bootstrap-daterangepicker/daterangepicker.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/generic.custom.validation.js",
                        "~/Content/plugin/select2/dist/js/select2.min.js",
                        "~/Content/js/app.js",//Lohana JS
                        "~/Content/js/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/plugin/bootstrap/css/bootstrap.min.css",
                      "~/Content/plugin/themify-icons/themify-icons.css",
                      "~/Content/plugin/font-awesome/css/font-awesome.min.css",
                      "~/Content/plugin/typicons/src/font/typicons.min.css",
                      "~/Content/plugin/animate.css/animate.min.css",
                      "~/Content/plugin/jscrollpane/jquery.jscrollpane.css",
                      "~/Content/plugin/waves/waves.min.css",
                      "~/Content/plugin/switchery/dist/switchery.min.css",
                      "~/Content/plugin/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.css",
                      "~/Content/plugin/multi-select/css/multi-select.css",
                      "~/Content/plugin/bootstrap-tagsinput/dist/bootstrap-tagsinput.css",
                      "~/Content/plugin/dropify/dist/css/dropify.min.css",
                      "~/Content/plugin/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css",
                      "~/Content/plugin/clockpicker/dist/bootstrap-clockpicker.min.css",
                      "~/Content/plugin/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                      "~/Content/plugin/bootstrap-daterangepicker/daterangepicker.css",
                      "~/Content/plugin/select2/dist/css/select2.min.css",
                      "~/Content/css/core.css", // Neptune CSS
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
