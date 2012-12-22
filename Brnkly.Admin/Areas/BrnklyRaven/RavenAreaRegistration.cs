using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using AutoMapper;
using Brnkly.Raven.Admin.Models;

namespace Brnkly.Raven.Admin
{
    public class RavenAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "BrnklyRaven"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            this.RegisterMvcRoutes(context);
            this.RegisterwebApiRoutes(GlobalConfiguration.Configuration);
            this.RegisterBundles(BundleTable.Bundles);
            this.ConfigureAutoMapper();
        }

        private void RegisterMvcRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Brnkly-Raven-Default",
                "raven/{controller}/{action}/{id}",
                new { controller = "Raven", action = "Index", id = UrlParameter.Optional }
            );
        }

        public void RegisterwebApiRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Brnkly-Raven-Api",
                routeTemplate: "api/raven/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/scripts/brnkly.js")
                    .Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-responsive.js",
                        "~/Scripts/knockout.js",
                        "~/Scripts/knockout.mapping-latest.js",
                        "~/Scripts/linq.js",
                        "~/Scripts/brnkly-knockout-extensions.js",
                        "~/Scripts/brnkly-raven.js"));

            bundles.Add(
                new StyleBundle("~/content/brnkly.css")
                    .Include(
                        "~/Content/bootstrap.css",
                        "~/Content/brnkly-styles.css"));
        }

        public void ConfigureAutoMapper()
        {
            Mapper.CreateMap<RavenConfig, RavenConfigModel>();
            Mapper.CreateMap<RavenConfigModel, RavenConfig>();

            Mapper.CreateMap<Store, StoreModel>();
            Mapper.CreateMap<StoreModel, Store>();

            Mapper.CreateMap<Instance, InstanceModel>();
            Mapper.CreateMap<InstanceModel, Instance>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
