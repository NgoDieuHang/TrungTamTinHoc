using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTTH.Common;

namespace TrungTamTinHoc.Areas.Home.Models
{
    public class ForgetPasswordController : Controller
    {
        // GET: Home/ForgetPassword
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public JsonResult CheckAccountForgetPass(string email)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = new ForgetPasswordModel().CheckAccountForgetPass(email);
            }
            catch (Exception e)
            {
                response.ThongTinBoSung1 = e.Message;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}