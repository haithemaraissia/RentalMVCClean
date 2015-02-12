using System.Web.Optimization;
using BundleTransformer.Core.Transformers;
using RentalMobile.Bundles;

namespace RentalMobile.App_Start
{
    /// <summary>
    /// Configuration of all bundle declarations.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers the bundles into the bundle collection on startup.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // set this to true to override web.config setting optimization mode based on debug compilation
            // allows you to programmatically determine if bundling is enabled via a custom methodology.
             BundleTable.EnableOptimizations = true;

             // CDN will use the distributed network when enabled, and in optimization mode
             bundles.UseCdn = true;
             var jqueryBundle = new ScriptBundle("~/bundles/jquery", "http://code.jquery.com/jquery-latest.min.js").Include(
                 "~/Scripts/jquery-{version}.js");
             jqueryBundle.CdnFallbackExpression = "window.jquery";
             bundles.Add(jqueryBundle);

            //Framework//
             bundles.Add(new ScriptBundle("~/bundles/framework").Include(
                "~/Scripts/js/jquery.bxslider.min.js",
                "~/Scripts/js/jquery.easytabs.min.js",
                "~/Scripts/js/switcher.js",
                "~/Scripts/js/jquery.dropdown.js",
                "~/Scripts/js/jquery.tipsy.js",
                "~/Scripts/js/jquery.customSelect.min.js",
                "~/Scripts/js/jquery.validate.min.js",
                "~/Scripts/js/jquery.validate.unobtrusive.min.js"));

            //Style//
            bundles.Add(new Bundle("~/bundles/style", new StyleTransformer()).Include(
                "~/css/dotcss/base.css",
                "~/css/dotcss/skeleton.css",
                "~/css/dotcss/layout.css",
                "~/css/dotcss/PagedList.css"));

            //Home//
             bundles.Add(new ScriptBundle("~/bundles/scripts/home").Include(
                "~/Scripts/app/home/app.js"));
             bundles.Add(new Bundle("~/bundle/styles/home", new StyleTransformer()).Include(
                "~/css/dotcss/jquery.bxslider.css"));



        }
    }
 
}

