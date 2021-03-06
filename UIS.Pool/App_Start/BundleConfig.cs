﻿using System.Web;
using System.Web.Optimization;

namespace UIS.Pool
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
                      "~/Content/angular-toastr.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Angular").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-animate.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-cookies.js",
                    "~/Scripts/angular-sanitize.js",
                    "~/Scripts/angular-toastr.js",
                    "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                ));

            bundles.Add(new Bundle("~/Scripts/Core").Include(
                "~/Scripts/Modules/pool/Configuration/app-registration.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/PoolModule")
                .IncludeDirectory("~/Scripts/Modules/pool/Filters", "*.js")
                .IncludeDirectory("~/Scripts/Modules/pool/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/Modules/pool/Services", "*.js")
                );
        }
    }
}
