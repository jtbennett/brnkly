using System.Web.Mvc;

namespace Brnkly.Admin
{
    public class BrnklyRootAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "BrnklyRoot"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BrnklyRoot-Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
