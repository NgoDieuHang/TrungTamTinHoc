using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    public class KhoaHoc
    {
        public string BeautyId { get; set; }

        public int SoLuongView { get; set; }

        public string AnhMinhHoa { get; set; }

        public string TenKhoaHoc { get; set; }

        public string TomTat { get; set; }

        public float DiemDanhGia { get; set; }

        public string TacGia { get; set; }

        public DateTime NgayDang { get; set; }

        public int SoLuongComment { get; set; }

    }
}