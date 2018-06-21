using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("User")]
    public partial class User : TableHaveIdInt
    {
        public User()
        {
            Account = new HashSet<Account>();
            BienLaiThuTien = new HashSet<BienLaiThuTien>();
            BienLaiXuatTien = new HashSet<BienLaiXuatTien>();
            CommentKhoaHoc = new HashSet<CommentKhoaHoc>();
            CommentTinTuc = new HashSet<CommentTinTuc>();
            ChamCong = new HashSet<ChamCong>();
            DangKyDayBu = new HashSet<DangKyDayBu>();
            DangKyLopHoc = new HashSet<DangKyLopHoc>();
            DanhGiaKhoaHoc = new HashSet<DanhGiaKhoaHoc>();
            DanhGiaTinTuc = new HashSet<DanhGiaTinTuc>();
            FileHoSo = new HashSet<FileHoSo>();
            GiangVienDungLop = new HashSet<GiangVienDungLop>();
            HocVien = new HashSet<HocVien>();
            HocVienDaGioiThieu = new HashSet<HocVien>();
            LichSuTaiSan = new HashSet<LichSuTaiSan>();
            LuongNhanVien = new HashSet<LuongNhanVien>();
            ThanhToanLuong = new HashSet<ThanhToanLuong>();
            ThongBaoDaNhan = new HashSet<ThongBao>();
            ThongBaoDaGui = new HashSet<ThongBao>();
            NguoiSeGiamHo = new HashSet<User>();
        }

        [Required]
        [StringLength(50)]
        public string Ho { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        [Required]
        [StringLength(255)]
        public string Avatar { get; set; }

        public bool GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(12)]
        public string CMND { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(5)]
        public string IdXa { get; set; }

        public int? IdNguoiGiamHo { get; set; }

        public int? IdThongTinBoSung { get; set; }
        
        public virtual ICollection<Account> Account { get; set; }
        
        public virtual ICollection<BienLaiThuTien> BienLaiThuTien { get; set; }
        
        public virtual ICollection<BienLaiXuatTien> BienLaiXuatTien { get; set; }
        
        public virtual ICollection<CommentKhoaHoc> CommentKhoaHoc { get; set; }
        
        public virtual ICollection<CommentTinTuc> CommentTinTuc { get; set; }
        
        public virtual ICollection<ChamCong> ChamCong { get; set; }
        
        public virtual ICollection<DangKyDayBu> DangKyDayBu { get; set; }
        
        public virtual ICollection<DangKyLopHoc> DangKyLopHoc { get; set; }
        
        public virtual ICollection<DanhGiaKhoaHoc> DanhGiaKhoaHoc { get; set; }
        
        public virtual ICollection<DanhGiaTinTuc> DanhGiaTinTuc { get; set; }
        
        public virtual ICollection<FileHoSo> FileHoSo { get; set; }
        
        public virtual ICollection<GiangVienDungLop> GiangVienDungLop { get; set; }
        
        public virtual ICollection<HocVien> HocVien { get; set; }
        
        public virtual ICollection<HocVien> HocVienDaGioiThieu { get; set; }
        
        public virtual ICollection<LichSuTaiSan> LichSuTaiSan { get; set; }
        
        public virtual ICollection<LuongNhanVien> LuongNhanVien { get; set; }
        
        public virtual ICollection<ThanhToanLuong> ThanhToanLuong { get; set; }
        
        public virtual ICollection<ThongBao> ThongBaoDaNhan { get; set; }
        
        public virtual ICollection<ThongBao> ThongBaoDaGui { get; set; }

        public virtual ThongTinBoSung ThongTinBoSung { get; set; }
        
        public virtual ICollection<User> NguoiSeGiamHo { get; set; }

        public virtual User NguoiGiamHo { get; set; }

        public virtual Xa Xa { get; set; }
    }
}
