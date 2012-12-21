using System.Web.Mvc;
using AutoMapper;
using Brnkly.Raven.Admin.Models;

namespace Brnkly.Raven.Admin
{
    public class RavenAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "Raven"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Raven_default",
                "raven/{controller}/{action}/{id}",
                new { controller = "Raven", action = "Index", id = UrlParameter.Optional }
            );

            this.ConfigureAutoMapper();
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
