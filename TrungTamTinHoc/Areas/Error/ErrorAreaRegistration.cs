using System.Web.Mvc;

namespace TrungTamTinHoc.Areas.Error
{
    public class ErrorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "error";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "errorNotAccess",
                "error/not-access",
                new { controller = "Error", action = "NotAccess" }
            );
            context.MapRoute(
                "errorError",
                "error/have-error",
                new { controller = "Error", action = "Error" }
            );
            context.MapRoute(
                "errorNotFound",
                "error/not-found",
                new { controller = "Error", action = "NotFound" }
            );
            context.MapRoute(
                "errorServerError",
                "error/server-error",
                new { controller = "Error", action = "ServerError" }
            );
            context.MapRoute(
                "errorDefault",
                "error/{controller}/{action}/{id}",
                new { controller = "Error", action = "Error", id = UrlParameter.Optional }
            );
        }
    }
}