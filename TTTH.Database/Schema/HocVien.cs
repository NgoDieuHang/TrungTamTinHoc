using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("HocVien")]
    public partial class HocVien : TableHaveIdInt
    {
        public HocVien()
        {
            DiemCuaHocVien = new HashSet<DiemCuaHocVien>();
            DiemDanh = new HashSet<DiemDanh>();
        }

        public int IdUser { get; set; }

        public int IdLopHoc { get; set; }

        public DateTime ThoiGanBatDauHoc { get; set; }

        public DateTime ThoiGanKetThucHoc { get; set; }

        public double SoTietDaHoc { get; set; }

        public int? IdLopDaHoc { get; set; }

        public int IdTrangThaiHienTai { get; set; }

        public int? IdTrangThaiTruocDo { get; set; }

        public int? IdNguoiGioiThieu { get; set; }

        public bool DaNopTien { get; set; }

        public int IdBienLaiNhap { get; set; }

        public virtual BienLaiThuTien BienLaiThuTien { get; set; }

        public virtual ICollection<DiemCuaHocVien> DiemCuaHocVien { get; set; }

        public virtual ICollection<DiemDanh> DiemDanh { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual LopHoc LopDaHoc { get; set; }

        public virtual TrangThai TrangThaiHienTai { get; set; }

        public virtual TrangThai TrangThaiTruocDo { get; set; }

        public virtual User User { get; set; }

        public virtual User NguoiGioiThieu { get; set; }
    }
}
