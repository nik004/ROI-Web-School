using System.Web.Optimization;

namespace AjaxTestApplication
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/ajaxLoad").Include(
                 "~/Scripts/AjaxLoadDoc.js", // The Virtual Path for the file
                 "~/Scripts/CreateXhr.js")); // The Virtual Path for the file

            //includes all files that is debug or minified but not .vsdoc
            //and match the wild card string "~/Scripts/jquery-{version}.js"
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                 "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryAll").IncludeDirectory(
                "~/Scripts/jquery", // The Virtual Path for the directory.
                "*.js",             // The search pattern.
                true));             // true to search subdirectories

            bundles.Add(new ScriptBundle("~/Scripts/jquery.unobtrusive").Include(
                 "~/Scripts/jquery/jquery.unobtrusive-ajax.min.js"));

            // add CDN jQuery bundle            
            bundles.UseCdn = true;   //enable CDN support
            var cdnPath = "http://ajax.googleapis.com/ajax/libs/jquery/2.1.0/jquery.min.js";
            var jqueryBundle = new ScriptBundle("~/Scripts/jqueryCdn", cdnPath)
            {
                //CdnFallbackExpression is used when even CDN server is unavailable.
                CdnFallbackExpression = "window.jquery"
            };

            // replaces the local jQuery bundle with a CDN jQuery bundle
            bundles.Add(jqueryBundle.Include("~/Scripts/jquery/jquery-{version}.js"));
        }
    }
}

