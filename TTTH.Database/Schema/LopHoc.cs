using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LopHoc")]
    public partial class LopHoc : TableHaveIdInt
    {
        public LopHoc()
        {
            DangKyDayBu = new HashSet<DangKyDayBu>();
            DangKyLopHoc = new HashSet<DangKyLopHoc>();
            DiemDanh = new HashSet<DiemDanh>();
            GiangVienDungLop = new HashSet<GiangVienDungLop>();
            HocVien = new HashSet<HocVien>();
            HocVienCu = new HashSet<HocVien>();
            LichHoc = new HashSet<LichHoc>();
            LopHocTrans = new HashSet<LopHocTrans>();
        }

        public int IdKhoaHoc { get; set; }

        public double SoTiet { get; set; }

        public int ThoiGianMoiTiet { get; set; }

        [Column(TypeName = "money")]
        public decimal HocPhi { get; set; }

        public int SoLuongHocVien { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

        public double ChietKhau { get; set; }
        
        public virtual ICollection<DangKyDayBu> DangKyDayBu { get; set; }
        
        public virtual ICollection<DangKyLopHoc> DangKyLopHoc { get; set; }
        
        public virtual ICollection<DiemDanh> DiemDanh { get; set; }
        
        public virtual ICollection<GiangVienDungLop> GiangVienDungLop { get; set; }
        
        public virtual ICollection<HocVien> HocVien { get; set; }
        
        public virtual ICollection<HocVien> HocVienCu { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
        
        public virtual ICollection<LichHoc> LichHoc { get; set; }
        
        public virtual ICollection<LopHocTrans> LopHocTrans { get; set; }
    }
}
