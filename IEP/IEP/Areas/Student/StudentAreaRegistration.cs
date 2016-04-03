using System.Web.Mvc;

namespace IEP.Areas.Student
{
    public class StudentAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Student";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Student_default",
                "student/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}