using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("PhongHoc")]
    public partial class PhongHoc : TableHaveIdInt
    {
        public PhongHoc()
        {
            DangKyDayBu = new HashSet<DangKyDayBu>();
            LichHoc = new HashSet<LichHoc>();
            PhongHocTrans = new HashSet<PhongHocTrans>();
            TaiSanTrongPhong = new HashSet<TaiSanTrongPhong>();
        }

        public int SoHocVienToiDa { get; set; }
        
        public virtual ICollection<DangKyDayBu> DangKyDayBu { get; set; }
        
        public virtual ICollection<LichHoc> LichHoc { get; set; }
        
        public virtual ICollection<PhongHocTrans> PhongHocTrans { get; set; }
        
        public virtual ICollection<TaiSanTrongPhong> TaiSanTrongPhong { get; set; }
    }
}
