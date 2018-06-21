using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("TrangThai")]
    public partial class TrangThai : TableHaveIdInt
    {
        public TrangThai()
        {
            Contact = new HashSet<Contact>();
            DangKyDayBu = new HashSet<DangKyDayBu>();
            DangKyLopHoc = new HashSet<DangKyLopHoc>();
            HocVien = new HashSet<HocVien>();
            HocVienCu = new HashSet<HocVien>();
            TrangThaiTrans = new HashSet<TrangThaiTrans>();
        }

        public int LoaiTrangThai { get; set; }

        public int Order { get; set; }
        
        public virtual ICollection<Contact> Contact { get; set; }
        
        public virtual ICollection<DangKyDayBu> DangKyDayBu { get; set; }
        
        public virtual ICollection<DangKyLopHoc> DangKyLopHoc { get; set; }
        
        public virtual ICollection<HocVien> HocVien { get; set; }
        
        public virtual ICollection<HocVien> HocVienCu { get; set; }
        
        public virtual ICollection<TrangThaiTrans> TrangThaiTrans { get; set; }
    }
}
