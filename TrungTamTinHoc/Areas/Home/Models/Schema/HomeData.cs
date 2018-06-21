using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    public class HomeData
    {
        public List<Slides> Slides { get; set; }
        public string WhyUs { get; set; }
        public Course Course { get; set; }
        public List<NhungDieuDatDuoc> NhungDieuDatDuocs { get; set; }
    }
}