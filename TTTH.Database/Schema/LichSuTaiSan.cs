using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LichSuTaiSan")]
    public partial class LichSuTaiSan : TableHaveIdInt
    {
        public int IdTaiSan { get; set; }

        public int HinhThuc { get; set; }

        public double SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        public int? IdBienLaiXuat { get; set; }

        public int? IdBienLaiNhap { get; set; }

        public DateTime NgayDienRa { get; set; }

        public int NguoiChiuTrachNhiem { get; set; }

        public virtual BienLaiThuTien BienLaiThuTien { get; set; }

        public virtual BienLaiXuatTien BienLaiXuatTien { get; set; }

        public virtual TaiSanTrongPhong TaiSanTrongPhong { get; set; }

        public virtual User User { get; set; }
    }
}
