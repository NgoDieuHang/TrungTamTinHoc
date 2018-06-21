using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TblAccount = TTTH.DataBase.Schema.Account;
using TTTH.Common;
using TTTH.Validate;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    public class DangKyTaiKhoanController : Controller
    {
        // GET: Home/DangKyTaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KichHoat()
        {
            return View();
        }

        public ActionResult ConfirmAccount(string username, string tokenactive)
        {
            if (new RegisterModel().CheckRegister(username, tokenactive))
                return RedirectToAction("Index", "Login", new { area = "Home" });
            else
                return View();
        }
        
        public JsonResult CreateAccount(NewAccount account)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = new RegisterModel().TaoAccount(account);
                    
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
        
    }
}