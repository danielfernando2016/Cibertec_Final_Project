using System.Web.Mvc;

namespace WebDeveloper.Areas.Personal
{
    public class PersonAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Personal";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Personal_default",
                "Personal/{action}/{id}",
                new { controller="Personal", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}