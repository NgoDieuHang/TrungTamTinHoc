using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("TaiSanTrongPhong")]
    public partial class TaiSanTrongPhong : TableHaveIdInt
    {
        public TaiSanTrongPhong()
        {
            LichSuTaiSan = new HashSet<LichSuTaiSan>();
        }
        
        public int IdPhongHoc { get; set; }

        public int IdLoaiTaiSan { get; set; }

        [Required]
        [StringLength(20)]
        public string KyHieu { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        public double SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime ThoiGianBatDauSuDung { get; set; }
        
        public virtual ICollection<LichSuTaiSan> LichSuTaiSan { get; set; }

        public virtual LoaiTaiSan LoaiTaiSan { get; set; }

        public virtual PhongHoc PhongHoc { get; set; }
    }
}
