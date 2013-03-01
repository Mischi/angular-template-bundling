using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AngularTemplateBundling.Demo
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/js/app").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/app.js"));

            bundles.Add(new NgTemplateBundle("~/js/tmpl", "template-bundle-demo").Include("~/Templates/*.html"));

            bundles.Add(new StyleBundle("~/css/app").Include("~/Content/site.css"));
        }
    }
}