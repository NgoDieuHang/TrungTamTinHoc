using System.Web.Mvc;

namespace TrungTamTinHoc.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "homeCheckLogin",
                "home/login/check-login",
                new { controller = "Login", action = "CheckLogin", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeCheckLoginfb",
                "home/login/check-login-fb",
                new { controller = "Login", action = "LoginByFB", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "homeCheckLogingg",
                "home/login/check-login-gg",
                new { controller = "Login", action = "LoginByGG", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeLogout",
                "home/logout",
                new { controller = "Login", action = "Logout", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeCreateAccount",
                "home/create-account",
                new { controller = "DangKyTaiKhoan", action = "CreateAccount", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeKichHoat",
                "home/kich-hoat",
                new { controller = "DangKyTaiKhoan", action = "KichHoat", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeConfirm",
                "home/confirm",
                new { controller = "DangKyTaiKhoan", action = "ConfirmAccount", id = UrlParameter.Optional }
            ); 
            context.MapRoute(
                "homeForgetPass",
                "home/quen-mat-khau",
                new { controller = "ForgetPassword", action = "ForgetPassword", id = UrlParameter.Optional }
            ); 
             context.MapRoute(
                "homeCheckAccountForgetPass",
                "home/check-account-forget-pass",
                new { controller = "ForgetPassword", action = "CheckAccountForgetPass", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeDefault",
                "home/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}