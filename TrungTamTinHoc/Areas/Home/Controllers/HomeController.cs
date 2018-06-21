using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.DataBase;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Home
        public ActionResult Index()
        {
            HomeData data = new HomeData();
            HomeModel model = new HomeModel();
            data.Slides = model.LaySlide();
            data.WhyUs = model.GetWhyUs();
            data.Course = model.GetCourse();
            data.NhungDieuDatDuocs = model.GetNhungDieuDatDuoc();
            return View("Home", data);
        }

        public ActionResult About()
        {
            ViewBag.about = new HomeModel().GetAbout();
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Support()
        {
            ViewBag.support = new HomeModel().Getsupport();
            return View();
        }

        public ActionResult TermsConditions()
        {
            ViewBag.termsConditions = new HomeModel().GetTermsConditions();
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            ViewBag.privacyPolicy = new HomeModel().GetPrivacyPolicy();
            return View();
        }
    }
}