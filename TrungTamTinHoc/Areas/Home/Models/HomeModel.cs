using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;

namespace TrungTamTinHoc.Areas.Home.Models
{
    /// <summary>
    /// Xử lý các hoạt động tương tác với cơ sở dữ liệu trên trang home
    /// Author      :   HangNTD - 11/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package     :   Home.Models
    /// </remarks>
    public class HomeModel
    {
        private DataContext context;

        public HomeModel()
        {
            context = new DataContext();
        }
        /// <summary>
        /// Lấy dữ liệu slide từ cơ sở dữ liệu
        /// Author:     HangNTD - 11/06/2018 - create
        /// </summary>
        /// <param ></param>
        /// <returns>nếu thành công thì trả về list dữ liệu cần thiết</returns>
        public List<Slides> LaySlide()
        {
            try
            {
                string lang = Common.GetLang();
                return context.Slide.Where(x => x.Lang == lang && x.HienThi && !x.DelFlag).Select(x => new Slides
                {
                    TieuDe = x.TieuDe,
                    ChiTiet = x.ChiTiet,
                    LinkAnh = x.LinkAnh,
                    Link = x.Link
                }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetWhyUs()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && !x.DelFlag)?.WhyUs;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       public Course GetCourse()
        {
            try
            {
                Course course = new Course();
                string lang = Common.GetLang();
                course.Title = context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && !x.DelFlag)?.GioiThieuChungKhoaHoc;
                course.KhoaHoc = context.KhoaHocTrans.Where(x => x.Lang == lang && !x.DelFlag).Select(x => new KhoaHoc
                {
                    BeautyId = x.KhoaHoc.BeautyId,
                    SoLuongView = x.KhoaHoc.SoLuongView,
                    SoLuongComment = x.KhoaHoc.CommentKhoaHoc.Count,
                    AnhMinhHoa = x.KhoaHoc.AnhMinhHoa,
                    TenKhoaHoc = x.TenKhoaHoc,
                    TomTat = x.TomTat,
                    TacGia = "IPro",
                    NgayDang = DateTime.Today,
                    DiemDanhGia =(float) x.KhoaHoc.DanhGiaKhoaHoc.Sum(p=>p.DiemDanhGIa)/(x.KhoaHoc.DanhGiaKhoaHoc.Count)
                }).OrderByDescending(x=>x.NgayDang).Take(3).ToList();
                return course;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<NhungDieuDatDuoc> GetNhungDieuDatDuoc()
        {
            try
            {
                string lang = Common.GetLang();
                return context.NhungDieuDatDuoc.Where(x => x.Lang == lang && x.IsShow == !x.DelFlag).Select(x => new NhungDieuDatDuoc
                {
                    Icon = x.Icon,
                    Title = x.Title,
                    Content = x.Content
                }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetAbout()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && !x.DelFlag)?.About;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Getsupport()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && !x.DelFlag)?.HuongDanSuDung;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetTermsConditions()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && !x.DelFlag && x.Id == 1)?.DieuKhoanSuDung;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetPrivacyPolicy()
        {
            try
            {
                string lang = Common.GetLang();
                return context.CaiDatHeThong.FirstOrDefault(x => x.Lang == lang && !x.DelFlag)?.ChinhSachBaoMat;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}