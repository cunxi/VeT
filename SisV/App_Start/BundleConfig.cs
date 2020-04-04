using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SisV
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/css/style.css",
                "~/Content/css/main-color.css"));


            bundles.Add(new ScriptBundle("~/bundles/js")
               .Include(
               "~/Content/scripts/jquery-3.4.1.min.js",
               "~/Content/scripts/jquery-migrate-3.1.0.min.js",
               "~/Content/scripts/mmenu.min.js",
               "~/Content/scripts/chosen.min.js",
               "~/Content/scripts/slick.min.js",
               "~/Content/scripts/rangeslider.min.js",
               "~/Content/scripts/magnific-popup.min.js",
               "~/Content/scripts/waypoints.min.js",
               "~/Content/scripts/counterup.min.js",
               "~/Content/scripts/jquery-ui.min.js",
               "~/Content/scripts/tooltips.min.js",
               "~/Content/scripts/custom.js",
               "~/Content/scripts/leaflet.min.js",
               "~/Content/scripts/leaflet-markercluster.min.js",
               "~/Content/scripts/leaflet-gesture-handling.min.js",
               "~/Content/scripts/leaflet-listeo.js",
               "~/Content/scripts/leaflet-autocomplete.js",
               "~/Content/scripts/leaflet-control-geocoder.js"));

        }
    }
}