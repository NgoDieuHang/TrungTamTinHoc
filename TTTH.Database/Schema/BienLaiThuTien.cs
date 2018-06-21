using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("BienLaiThuTien")]
    public partial class BienLaiThuTien : TableHaveIdInt
    {
        public BienLaiThuTien()
        {
            HocVien = new HashSet<HocVien>();
            LichSuTaiSan = new HashSet<LichSuTaiSan>();
        }

        [Required]
        [StringLength(50)]
        public string HoTenNguoiNop { get; set; }

        public int IdNguoiThu { get; set; }

        [Required]
        [StringLength(20)]
        public string SoBienLai { get; set; }

        public DateTime NgayThu { get; set; }

        [Required]
        [StringLength(1000)]
        public string NoiDungThu { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<HocVien> HocVien { get; set; }

        public virtual ICollection<LichSuTaiSan> LichSuTaiSan { get; set; }
    }
}
