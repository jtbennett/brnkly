using System.Web.Optimization;

namespace Brnkly.Admin
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/scripts/frameworks.js")
                    .Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-responsive.js",
                        "~/Scripts/knockout.js",
                        "~/Scripts/knockout.mapping-latest.js",
                        "~/Scripts/KnockoutBootstrapCheckboxBinding.js",
                        "~/Scripts/KnockoutBootstrapRadioBinding.js",
                        "~/Scripts/KnockoutDirtyFlag.js",
                        "~/Scripts/linq.js"));

            bundles.Add(
                new ScriptBundle("~/scripts/brnkly.js")
                    .Include(
                        "~/Scripts/BrnklyRaven.js"));

            bundles.Add(
                new StyleBundle("~/content/frameworks.css")
                    .Include(
                        "~/Content/bootstrap.css"));

            bundles.Add(
                new StyleBundle("~/content/brnkly.css")
                    .Include(
                        "~/Content/Brnkly.css"));
        }
    }
}