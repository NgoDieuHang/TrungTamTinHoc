using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("BienLaiXuatTien")]
    public partial class BienLaiXuatTien : TableHaveIdInt
    {
        public BienLaiXuatTien()
        {
            LichSuTaiSan = new HashSet<LichSuTaiSan>();
        }

        public int IdNguoiXuat { get; set; }

        [Required]
        [StringLength(20)]
        public string SoBienLai { get; set; }

        public DateTime NgayXuat { get; set; }

        [Required]
        [StringLength(1000)]
        public string NoiDungXuat { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<LichSuTaiSan> LichSuTaiSan { get; set; }
    }
}
