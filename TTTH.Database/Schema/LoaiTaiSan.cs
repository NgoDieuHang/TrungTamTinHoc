using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LoaiTaiSan")]
    public partial class LoaiTaiSan : TableHaveIdInt
    {
        public LoaiTaiSan()
        {
            LoaiTaiSanTrans = new HashSet<LoaiTaiSanTrans>();
            TaiSanTrongPhong = new HashSet<TaiSanTrongPhong>();
        }
        
        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }
        
        public virtual ICollection<LoaiTaiSanTrans> LoaiTaiSanTrans { get; set; }
        
        public virtual ICollection<TaiSanTrongPhong> TaiSanTrongPhong { get; set; }
    }
}
