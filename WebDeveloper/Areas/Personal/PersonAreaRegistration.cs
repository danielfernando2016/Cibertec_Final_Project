using System.Web.Mvc;

namespace WebDeveloper.Areas.Personal
{
    public class PersonAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Personal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Person_default",
                "Personal/{action}/{id}",
                new { controller="Personal", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}