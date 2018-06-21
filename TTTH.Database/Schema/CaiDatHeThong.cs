using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("CaiDatHeThong")]
    public partial class CaiDatHeThong : TableHaveLang
    {
        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkFB { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkGoogle { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Skype { get; set; }

        public double MucBaoHiemXH { get; set; }

        public double ThueTNCN1 { get; set; }

        public double ThueTNCN2 { get; set; }

        public double ThueTNCN3 { get; set; }

        [Column(TypeName = "money")]
        public decimal GioiHanThueTNCN1 { get; set; }

        [Column(TypeName = "money")]
        public decimal GioiHanThueTNCN2 { get; set; }

        [Column(TypeName = "money")]
        public decimal GioiHanThueTNCN3 { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string WhyUs { get; set; }

        [Required]
        public string TomTat { get; set; }

        public int SoLanChoPhepDangNhapSai { get; set; }

        public int ThoiGianKhoa { get; set; }

        public double KinhDo { get; set; }

        public double ViDo { get; set; }

        [Required]
        [StringLength(50)]
        public string GioiThieuChungKhoaHoc { get; set; }

        [Required]
        public string ChinhSachBaoMat { get; set; }

        [Required]
        public string DieuKhoanSuDung { get; set; }

        [Required]
        public string HuongDanSuDung { get; set; }
    }
}
