using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SisVDash
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/bower_components/bootstrap/css/bootstrap.min.css",
                "~/Content/assets/icon/feather/css/feather.css",
                "~/Content/assets/css/style.css",
                "~/Content/assets/css/jquery.mCustomScrollbar.css",
                "~/Content/bower_components/bootstrap/css/bootstrap.min.css",
                "~/Content/assets/pages/chart/radial/css/radial.css",
                "~/Content/assets/icon/feather/css/feather.css",
                "~/Content/bower_components/datatables.net-bs4/css/dataTables.bootstrap4.min.css",
                "~/Content/assets/pages/data-table/css/buttons.dataTables.min.css",
                "~/Content/bower_components/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css",
                "~/Content/assets/css/jquery.mCustomScrollbar.css",
                "~/Content/assets/images/favicon.ico"));


            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                 "~/Content/bower_components/jquery/js/jquery.min.js",
                 "~/Content/bower_components/jquery-ui/js/jquery-ui.min.js",
                 "~/Content/bower_components/popper.js/js/popper.min.js",
                 "~/Content/bower_components/bootstrap/js/bootstrap.min.js",
                 "~/Content/bower_components/jquery-slimscroll/js/jquery.slimscroll.js",
                 "~/Content/bower_components/modernizr/js/modernizr.js",
                 "~/Content/bower_components/chart.js/js/Chart.js",
                 "~/Content/assets/pages/widget/amchart/amcharts.js",
                 "~/Content/assets/pages/widget/amchart/serial.js",
                 "~/Content/assets/pages/widget/amchart/light.js",
                 "~/Content/assets/js/jquery.mCustomScrollbar.concat.min.js",
                 "~/Content/assets/js/SmoothScroll.js",
                 "~/Content/assets/js/pcoded.min.js",
                 "~/Content/assets/js/vartical-layout.min.js",
                 "~/Content/assets/pages/dashboard/custom-dashboard.js",
                 "~/Content/assets/js/script.min.js",
                 "~/Content/assets/pages/dashboard/analytic-dashboard.min.js",
                 "~/Content/bower_components/chart.js/js/Chart.js",
                 "~/Content/bower_components/modernizr/js/css-scrollbars.js",
                 "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                 "~/Content/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js",
                 "~/Content/assets/pages/data-table/js/jszip.min.js",
                 "~/Content/assets/pages/data-table/js/pdfmake.min.js",
                 "~/Content/assets/pages/data-table/js/vfs_fonts.js",
                 "~/Content/assets/pages/data-table/extensions/autofill/js/dataTables.autoFill.min.js",
                 "~/Content/assets/pages/data-table/extensions/autofill/js/dataTables.select.min.js",
                 "~/Content/bower_components/datatables.net-buttons/js/buttons.print.min.js",
                 "~/Content/bower_components/datatables.net-buttons/js/buttons.html5.min.js",
                 "~/Content/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js",
                 "~/Content/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js",
                 "~/Content/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js",
                 "~/Content/bower_components/i18next/js/i18next.min.js",
                 "~/Content/bower_components/i18next-xhr-backend/js/i18nextXHRBackend.min.js",
                 "~/Content/bower_components/i18next-browser-languagedetector/js/i18nextBrowserLanguageDetector.min.js",
                 "~/Content/bower_components/jquery-i18next/js/jquery-i18next.min.js",
                 "~/Content/assets/pages/data-table/extensions/autofill/js/extensions-custom.js",
                 "~/Content/assets/js/pcoded.min.js",
                 "~/Content/assets/js/vartical-layout.min.js",
                 "~/Content/assets/js/jquery.mCustomScrollbar.concat.min.js",
                 "~/Content/assets/js/script.js",

 "~/Content/bower_components/jquery/js/jquery.min.js",
 "~/Content/bower_components/jquery-ui/js/jquery-ui.min.js",
 "~/Content/bower_components/popper.js/js/popper.min.js",
 "~/Content/bower_components/bootstrap/js/bootstrap.min.js",
 "~/Content/bower_components/jquery-slimscroll/js/jquery.slimscroll.js",
 "~/Content/bower_components/modernizr/js/modernizr.js",
 "~/Content/bower_components/modernizr/js/css-scrollbars.js",
 "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
 "~/Content/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js",
 "~/Content/assets/pages/data-table/js/jszip.min.js",
 "~/Content/assets/pages/data-table/js/pdfmake.min.js",
 "~/Content/assets/pages/data-table/js/vfs_fonts.js",
 "~/Content/bower_components/datatables.net-buttons/js/buttons.print.min.js",
 "~/Content/bower_components/datatables.net-buttons/js/buttons.html5.min.js",
 "~/Content/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js",
 "~/Content/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js",
 "~/Content/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js",
 "~/Content/bower_components/i18next/js/i18next.min.js",
 "~/Content/bower_components/i18next-xhr-backend/js/i18nextXHRBackend.min.js",
 "~/Content/bower_components/i18next-browser-languagedetector/js/i18nextBrowserLanguageDetector.min.js",
 "~/Content/bower_components/jquery-i18next/js/jquery-i18next.min.js",
 "~/Content/assets/pages/data-table/js/data-table-custom.js",
 "~/Content/assets/js/pcoded.min.js",
 "~/Content/assets/js/vartical-layout.min.js",
 "~/Content/assets/js/jquery.mCustomScrollbar.concat.min.js",
 "~/Content/assets/js/script.js"



 ));

        }

    }
}