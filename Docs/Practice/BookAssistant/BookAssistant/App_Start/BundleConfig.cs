using System.Web.Optimization;

namespace BookAssistant.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Script/jqueryAjax").IncludeDirectory("~/Scripts/jquery","*.js"));
        }
    }
}