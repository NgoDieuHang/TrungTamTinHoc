using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.Validate;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    public class LoginController : Controller
    {
        // GET: Home/Login
        public ActionResult Index()
        {
            int idAccount = Common.GetIdAccount();
            if (idAccount != 0)
            {
                return RedirectToAction("Index", "Home", new {area = "Home"});
            }
            return View();
        }
        /// <summary>
        /// Action kiểm tra tài khoản login của người dùng
        /// </summary>
        /// <param name="account">Thông tin tài khoản mà người dùng gửi lên</param>
        /// <returns></returns>
        public JsonResult CheckLogin(Account account)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = new LoginModel().CheckAccount(account);
                }
                else
                {
                    response.Code = 201;
                    response.ListError = ModelState.GetModelErrors();
                }
            }
            catch (Exception e)
            {

                response.Code = 500;
                response.MsgNo = 100;
                response.ThongTinBoSung1 = e.Message;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Action xử lý việc logout của người dùng
        /// </summary>
        /// <param></param>
        /// <returns>Điều hướng về trang home nếu logout thành công</returns>
        public ActionResult Logout()
        {
            try
            {
                new LoginModel().RemoveToken();
                if (Request.Cookies["token"] != null)
                {
                    var c = new HttpCookie("token");
                    c.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(c);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new {area = "Home", error = e.Message});
            }
        }
        /// <summary>
        /// Action kiểm tra tài khoản login bằng facebook của người dùng
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public JsonResult LoginByFB(string accessToken)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                SocialAccount account = new LoginModel().LayThongTinFB(accessToken);
                response.ThongTinBoSung1 = new LoginModel().CheckSocialAccount(account).Token;
            }
            catch (Exception e)
            {

                response.Code = 500;
                response.MsgNo = 100;
                response.ThongTinBoSung1 = e.Message;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Action kiểm tra tài khoản login bằng google của người dùng
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public JsonResult LoginByGG(string accessToken)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                SocialAccount account = new LoginModel().LayThongTinGG(accessToken);
                response.ThongTinBoSung1 = new LoginModel().CheckSocialAccount(account).Token;
            }
            catch (Exception e)
            {

                response.Code = 500;
                response.MsgNo = 100;
                response.ThongTinBoSung1 = e.Message;
                throw;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}