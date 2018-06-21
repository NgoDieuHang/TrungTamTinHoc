using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using TTTH.DataBase.Schema;
using Z.EntityFramework.Plus;

namespace TTTH.DataBase
{
    public class DataContext : DbContext
    {
        public virtual DbSet<AuditEntry> Audit { set; get; }
        public virtual DbSet<AuditEntryProperty> AuditProperty { set; get; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<BienLaiThuTien> BienLaiThuTien { get; set; }
        public virtual DbSet<BienLaiXuatTien> BienLaiXuatTien { get; set; }
        public virtual DbSet<BieuMau> BieuMau { get; set; }
        public virtual DbSet<CaiDatHeThong> CaiDatHeThong { get; set; }
        public virtual DbSet<CommentKhoaHoc> CommentKhoaHoc { get; set; }
        public virtual DbSet<CommentTinTuc> CommentTinTuc { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ChamCong> ChamCong { get; set; }
        public virtual DbSet<ChucNang> ChucNang { get; set; }
        public virtual DbSet<ChucNangTrans> ChucNangTrans { get; set; }
        public virtual DbSet<ChuyenNganh> ChuyenNganh { get; set; }
        public virtual DbSet<ChuyenNganhTrans> ChuyenNganhTrans { get; set; }
        public virtual DbSet<DangKyDayBu> DangKyDayBu { get; set; }
        public virtual DbSet<DangKyLopHoc> DangKyLopHoc { get; set; }
        public virtual DbSet<DangKyTheoDoi> DangKyTheoDoi { get; set; }
        public virtual DbSet<DanhGiaKhoaHoc> DanhGiaKhoaHoc { get; set; }
        public virtual DbSet<DanhGiaTinTuc> DanhGiaTinTuc { get; set; }
        public virtual DbSet<DiemCuaHocVien> DiemCuaHocVien { get; set; }
        public virtual DbSet<DiemDanh> DiemDanh { get; set; }
        public virtual DbSet<ErrorMsg> ErrorMsg { get; set; }
        public virtual DbSet<FileHoSo> FileHoSo { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupOfAccount> GroupOfAccount { get; set; }
        public virtual DbSet<GroupTrans> GroupTrans { get; set; }
        public virtual DbSet<GiangVienDungLop> GiangVienDungLop { get; set; }
        public virtual DbSet<HocVien> HocVien { get; set; }
        public virtual DbSet<Huyen> Huyen { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHoc { get; set; }
        public virtual DbSet<KhoaHocTrans> KhoaHocTrans { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LichHoc> LichHoc { get; set; }
        public virtual DbSet<LichSuTaiSan> LichSuTaiSan { get; set; }
        public virtual DbSet<LinhVuc> LinhVuc { get; set; }
        public virtual DbSet<LinhVucTrans> LinhVucTrans { get; set; }
        public virtual DbSet<LoaiTaiSan> LoaiTaiSan { get; set; }
        public virtual DbSet<LoaiTaiSanTrans> LoaiTaiSanTrans { get; set; }
        public virtual DbSet<LopHoc> LopHoc { get; set; }
        public virtual DbSet<LopHocTrans> LopHocTrans { get; set; }
        public virtual DbSet<LuongNhanVien> LuongNhanVien { get; set; }
        public virtual DbSet<ManHinh> ManHinh { get; set; }
        public virtual DbSet<ManHinhTrans> ManHinhTrans { get; set; }
        public virtual DbSet<NhungDieuDatDuoc> NhungDieuDatDuoc { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PhongHoc> PhongHoc { get; set; }
        public virtual DbSet<PhongHocTrans> PhongHocTrans { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<TaiSanTrongPhong> TaiSanTrongPhong { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }
        public virtual DbSet<TinTucTrans> TinTucTrans { get; set; }
        public virtual DbSet<Tinh> Tinh { get; set; }
        public virtual DbSet<TokenLogin> TokenLogin { get; set; }
        public virtual DbSet<ThanhToanLuong> ThanhToanLuong { get; set; }
        public virtual DbSet<ThongBao> ThongBao { get; set; }
        public virtual DbSet<ThongTinBoSung> ThongTinBoSung { get; set; }
        public virtual DbSet<ThongTinBoSungTrans> ThongTinBoSungTrans { get; set; }
        public virtual DbSet<TrangThai> TrangThai { get; set; }
        public virtual DbSet<TrangThaiTrans> TrangThaiTrans { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ViTri> ViTri { get; set; }
        public virtual DbSet<Xa> Xa { get; set; }
        public virtual DbSet<XepLoai> XepLoai { get; set; }
        public DataContext()
           //@"Data Source=103.95.197.121;Initial Catalog=TrungTamTinHoc_DEV;User Id=sa;Password=Admin@123;MultipleActiveResultSets=True;"
           //@"Data Source=NGOCQUY\SQLEXPRESS;Initial Catalog=TrungTamTinHoc_DEV;Integrated Security=True;"
           : base(@"Data Source=103.95.197.121;Initial Catalog=TrungTamTinHoc_DEV;User Id=sa;Password=Admin@123;MultipleActiveResultSets=True;")
        {
            Database.SetInitializer<DataContext>(new TaoDataBase());
        }
        public DataContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<DataContext>(new TaoDataBase());
        }
        public override int SaveChanges()
        {
            try
            {
                if (ChangeTracker.HasChanges())
                {
                    foreach (var entry
                        in ChangeTracker.Entries())
                    {
                        var root = (Table)entry.Entity;
                        var now = DateTime.Now;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                {
                                    root.Created_at = now;
                                    root.Created_by = TaoDataBase.GetIdAccount();
                                    root.Updated_at = null;
                                    root.Updated_by = -1;
                                    root.DelFlag = false;
                                    break;
                                }
                            case EntityState.Modified:
                                {
                                    root.Updated_at = now;
                                    root.Updated_by = TaoDataBase.GetIdAccount();
                                    break;
                                }
                        }
                    }
                    var audit = new Audit();
                    audit.PreSaveChanges(this);
                    var rowAffecteds = base.SaveChanges();
                    audit.PostSaveChanges();

                    if (audit.Configuration.AutoSavePreAction != null)
                    {
                        audit.Configuration.AutoSavePreAction(this, audit);
                    }
                    return base.SaveChanges();
                }
                return 0;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.GroupOfAccount)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.IdAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TokenLogin)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.IdAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BienLaiThuTien>()
                .HasMany(e => e.HocVien)
                .WithRequired(e => e.BienLaiThuTien)
                .HasForeignKey(e => e.IdBienLaiNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BienLaiThuTien>()
                .HasMany(e => e.LichSuTaiSan)
                .WithOptional(e => e.BienLaiThuTien)
                .HasForeignKey(e => e.IdBienLaiNhap);

            modelBuilder.Entity<BienLaiXuatTien>()
                .HasMany(e => e.LichSuTaiSan)
                .WithOptional(e => e.BienLaiXuatTien)
                .HasForeignKey(e => e.IdBienLaiXuat);

            modelBuilder.Entity<CaiDatHeThong>()
                .Property(e => e.GioiHanThueTNCN1)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CaiDatHeThong>()
                .Property(e => e.GioiHanThueTNCN2)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CaiDatHeThong>()
                .Property(e => e.GioiHanThueTNCN3)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CommentKhoaHoc>()
                .HasMany(e => e.ChildComment)
                .WithOptional(e => e.ParentComment)
                .HasForeignKey(e => e.IdComment);

            modelBuilder.Entity<CommentTinTuc>()
                .HasMany(e => e.ChildComment)
                .WithOptional(e => e.ParentComent)
                .HasForeignKey(e => e.IdComment);

            modelBuilder.Entity<ChucNang>()
                .HasMany(e => e.ChucNangTrans)
                .WithRequired(e => e.ChucNang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChucNang>()
                .HasMany(e => e.Permission)
                .WithRequired(e => e.ChucNang)
                .HasForeignKey(e => e.IdChucNang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChuyenNganh>()
                .HasMany(e => e.ChuyenNganhTrans)
                .WithRequired(e => e.ChuyenNganh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChuyenNganh>()
                .HasMany(e => e.KhoaHoc)
                .WithRequired(e => e.ChuyenNganh)
                .HasForeignKey(e => e.IdChuyenNganh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupOfAccount)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupTrans)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Permission)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVienDungLop>()
                .Property(e => e.SoTienMoiTiet)
                .HasPrecision(19, 2);

            modelBuilder.Entity<HocVien>()
                .HasMany(e => e.DiemCuaHocVien)
                .WithRequired(e => e.HocVien)
                .HasForeignKey(e => e.IdHocVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocVien>()
                .HasMany(e => e.DiemDanh)
                .WithRequired(e => e.HocVien)
                .HasForeignKey(e => e.IdHocVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Huyen>()
                .HasMany(e => e.Xa)
                .WithRequired(e => e.Huyen)
                .HasForeignKey(e => e.IdHuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.CommentKhoaHoc)
                .WithRequired(e => e.KhoaHoc)
                .HasForeignKey(e => e.IdKhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.DanhGiaKhoaHoc)
                .WithRequired(e => e.KhoaHoc)
                .HasForeignKey(e => e.IdKhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.KhoaHocTrans)
                .WithRequired(e => e.KhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.LopHoc)
                .WithRequired(e => e.KhoaHoc)
                .HasForeignKey(e => e.IdKhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LichSuTaiSan>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LinhVuc>()
                .HasMany(e => e.ChuyenNganh)
                .WithRequired(e => e.LinhVuc)
                .HasForeignKey(e => e.IdLinhVuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LinhVuc>()
                .HasMany(e => e.LinhVucTrans)
                .WithRequired(e => e.LinhVuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTaiSan>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 2);

            modelBuilder.Entity<LoaiTaiSan>()
                .HasMany(e => e.LoaiTaiSanTrans)
                .WithRequired(e => e.LoaiTaiSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTaiSan>()
                .HasMany(e => e.TaiSanTrongPhong)
                .WithRequired(e => e.LoaiTaiSan)
                .HasForeignKey(e => e.IdLoaiTaiSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.HocPhi)
                .HasPrecision(19, 2);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.DangKyDayBu)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.IdLopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.DangKyLopHoc)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.IdLopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.DiemDanh)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.IdLopBoSung);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.GiangVienDungLop)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.IdLopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.HocVien)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.IdLopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.HocVienCu)
                .WithOptional(e => e.LopDaHoc)
                .HasForeignKey(e => e.IdLopDaHoc);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.LichHoc)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.IdLopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.LopHocTrans)
                .WithRequired(e => e.LopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LuongNhanVien>()
                .Property(e => e.TienLuong)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ManHinh>()
                .HasMany(e => e.ChucNang)
                .WithRequired(e => e.ManHinh)
                .HasForeignKey(e => e.IdScreen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ManHinh>()
                .HasMany(e => e.ManHinhTrans)
                .WithRequired(e => e.ManHinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongHoc>()
                .HasMany(e => e.DangKyDayBu)
                .WithRequired(e => e.PhongHoc)
                .HasForeignKey(e => e.IdPhongHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongHoc>()
                .HasMany(e => e.LichHoc)
                .WithRequired(e => e.PhongHoc)
                .HasForeignKey(e => e.IdPhongHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongHoc>()
                .HasMany(e => e.PhongHocTrans)
                .WithRequired(e => e.PhongHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongHoc>()
                .HasMany(e => e.TaiSanTrongPhong)
                .WithRequired(e => e.PhongHoc)
                .HasForeignKey(e => e.IdPhongHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiSanTrongPhong>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 2);

            modelBuilder.Entity<TaiSanTrongPhong>()
                .HasMany(e => e.LichSuTaiSan)
                .WithRequired(e => e.TaiSanTrongPhong)
                .HasForeignKey(e => e.IdTaiSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinTuc>()
                .HasMany(e => e.CommentTinTuc)
                .WithRequired(e => e.TinTuc)
                .HasForeignKey(e => e.IdTinTuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinTuc>()
                .HasMany(e => e.DanhGiaTinTuc)
                .WithRequired(e => e.TinTuc)
                .HasForeignKey(e => e.IdTinTuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinTuc>()
                .HasMany(e => e.TinTucTrans)
                .WithRequired(e => e.TinTuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tinh>()
                .HasMany(e => e.Huyen)
                .WithRequired(e => e.Tinh)
                .HasForeignKey(e => e.IdTinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThanhToanLuong>()
                .Property(e => e.TongLuong)
                .HasPrecision(19, 2);

            modelBuilder.Entity<ThanhToanLuong>()
                .Property(e => e.ThueTNCN)
                .HasPrecision(19, 2);

            modelBuilder.Entity<ThanhToanLuong>()
                .Property(e => e.BaoHiem)
                .HasPrecision(19, 2);

            modelBuilder.Entity<ThongTinBoSung>()
                .HasMany(e => e.ThongTinBoSungTrans)
                .WithRequired(e => e.ThongTinBoSung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinBoSung>()
                .HasMany(e => e.User)
                .WithOptional(e => e.ThongTinBoSung)
                .HasForeignKey(e => e.IdThongTinBoSung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.Contact)
                .WithRequired(e => e.TrangThai)
                .HasForeignKey(e => e.IdTrangThai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.DangKyDayBu)
                .WithRequired(e => e.TrangThai)
                .HasForeignKey(e => e.IdTrangThai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.DangKyLopHoc)
                .WithRequired(e => e.TrangThai)
                .HasForeignKey(e => e.TrangThaiDangKy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.HocVien)
                .WithOptional(e => e.TrangThaiTruocDo)
                .HasForeignKey(e => e.IdTrangThaiTruocDo);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.HocVienCu)
                .WithRequired(e => e.TrangThaiHienTai)
                .HasForeignKey(e => e.IdTrangThaiHienTai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.TrangThaiTrans)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Account)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BienLaiThuTien)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdNguoiThu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BienLaiXuatTien)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdNguoiXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CommentKhoaHoc)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IdUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CommentTinTuc)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IdUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ChamCong)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DangKyDayBu)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DangKyLopHoc)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DanhGiaKhoaHoc)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DanhGiaTinTuc)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IdUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FileHoSo)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IdUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.GiangVienDungLop)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HocVien)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HocVienDaGioiThieu)
                .WithOptional(e => e.NguoiGioiThieu)
                .HasForeignKey(e => e.IdNguoiGioiThieu);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LichSuTaiSan)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.NguoiChiuTrachNhiem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LuongNhanVien)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ThanhToanLuong)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ThongBaoDaNhan)
                .WithRequired(e => e.UserNhan)
                .HasForeignKey(e => e.IdUserNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ThongBaoDaGui)
                .WithRequired(e => e.UserGui)
                .HasForeignKey(e => e.IdUserGui)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NguoiSeGiamHo)
                .WithOptional(e => e.NguoiGiamHo)
                .HasForeignKey(e => e.IdNguoiGiamHo);

            modelBuilder.Entity<ViTri>()
                .HasMany(e => e.ThongTinBoSung)
                .WithRequired(e => e.ViTri)
                .HasForeignKey(e => e.IdViTri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Xa>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Xa)
                .HasForeignKey(e => e.IdXa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XepLoai>()
                .HasMany(e => e.DiemCuaHocVien)
                .WithRequired(e => e.XepLoai)
                .HasForeignKey(e => e.IdXepLoai)
                .WillCascadeOnDelete(false);
        }
        public class TaoDataBase : CreateDatabaseIfNotExists<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                context.Group.Add(new Group
                {
                    IsDefault = true,
                    IsSystem = true,
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 1,
                    Lang = "vi",
                    GroupName = "Lập trình viên",
                    MoTa = "Toàn quyền quản lý và cấu hình hệ thống cấp cao"
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 1,
                    Lang = "en",
                    GroupName = "Developer",
                    MoTa = "Toàn quyền quản lý và cấu hình hệ thống cấp cao"
                });
                context.Group.Add(new Group
                {
                    IsDefault = true,
                    IsSystem = false,
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 2,
                    Lang = "vi",
                    GroupName = "Quản trị viên",
                    MoTa = "Toàn quyền thực hiện các chức năng của hệ thống"
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 2,
                    Lang = "en",
                    GroupName = "Admin",
                    MoTa = "Toàn quyền thực hiện các chức năng của hệ thống"
                });
                context.Group.Add(new Group
                {
                    IsDefault = true,
                    IsSystem = false,
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 3,
                    Lang = "vi",
                    GroupName = "Người dùng",
                    MoTa = "Người sử dụng các chức năng ở trang chủ"
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 3,
                    Lang = "en",
                    GroupName = "User",
                    MoTa = "Người sử dụng các chức năng ở trang chủ"
                });
                context.Group.Add(new Group
                {
                    IsDefault = true,
                    IsSystem = false,
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 4,
                    Lang = "vi",
                    GroupName = "Học viên",
                    MoTa = "Nhóm quyền dành cho các chức năng của học viên"
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 4,
                    Lang = "en",
                    GroupName = "Student",
                    MoTa = "Nhóm quyền dành cho các chức năng của học viên"
                });
                context.Group.Add(new Group
                {
                    IsDefault = true,
                    IsSystem = false,
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 5,
                    Lang = "vi",
                    GroupName = "Giảng viên",
                    MoTa = "Nhóm quyền dành cho các chức năng của giảng viên"
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 5,
                    Lang = "en",
                    GroupName = "Teacher",
                    MoTa = "Nhóm quyền dành cho các chức năng của giảng viên"
                });
                context.Group.Add(new Group
                {
                    IsDefault = true,
                    IsSystem = false,
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 6,
                    Lang = "vi",
                    GroupName = "Nhân viên",
                    MoTa = "Nhóm quyền dành cho các chức năng của nhân viên"
                });
                context.GroupTrans.Add(new Schema.GroupTrans
                {
                    Id = 6,
                    Lang = "en",
                    GroupName = "Employee",
                    MoTa = "Nhóm quyền dành cho các chức năng của nhân viên"
                });
                context.User.Add(new User
                {
                    Ho = "Phạm Ngọc",
                    Ten = "Quý",
                    Avatar = "http://2.bp.blogspot.com/-Fl8NZJZFq6w/U02LSHQ7iII/AAAAAAAAAHg/zpzikQfynpM/s1600/WAPHAYVL.MOBI-CONDAU+(11).gif",
                    GioiTinh = true,
                    NgaySinh = new DateTime(1993, 9, 22),
                    SoDienThoai = "01685651137",
                    CMND = "191796438",
                    DiaChi = "35 Nguyễn Chánh"
                });
                context.SaveChanges();
                context.Account.Add(new Account
                {
                    Username = "admin",
                    Password = GetMD5(GetSimpleMD5("admin")),
                    Email = "ngocquy220993@gmail.com",
                    TokenActive = "",
                    IsActived = true,
                    SoLanDangNhapSai = 0,
                    KhoaTaiKhoanDen = DateTime.Now,
                    IdUser = 1
                });
                context.GroupOfAccount.Add(new GroupOfAccount
                {
                    IdGroup = 1,
                    IdAccount = 1
                });
                context.Language.Add(new Language {
                    Id = "vi",
                    Name = "Tiếng Việt"
                });
                context.Language.Add(new Language
                {
                    Id = "en",
                    Name = "English"
                });
            }
            /// <summary>
            /// Mã hóa MD5 của 1 chuỗi có thêm chuối khóa đầu và cuối.
            /// Author       :   QuyPN - 06/05/2018 - create
            /// </summary>
            /// <param name="str">
            /// Chuỗi cần mã hóa.
            /// </param>
            /// <returns>
            /// Chuỗi sau khi đã được mã hóa.
            /// </returns>
            public static string GetMD5(string str)
            {
                str = "TRUNGTAMTINHOC" + str + "TRUNGTAMTINHOC";
                string str_md5 = "";
                byte[] mang = System.Text.Encoding.UTF8.GetBytes(str);
                MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
                mang = my_md5.ComputeHash(mang);
                foreach (byte b in mang)
                {
                    str_md5 += b.ToString("x2");
                }
                return str_md5;
            }
            /// <summary>
            /// Mã hóa MD5 của 1 chuỗi không có thêm chuối khóa đầu và cuối.
            /// Author       :   QuyPN - 06/05/2018 - create
            /// </summary>
            /// <param name="str">
            /// Chuỗi cần mã hóa.
            /// </param>
            /// <returns>
            /// Chuỗi sau khi đã được mã hóa
            /// </returns>
            public static string GetSimpleMD5(string str)
            {
                string str_md5 = "";
                byte[] mang = System.Text.Encoding.UTF8.GetBytes(str);
                MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
                mang = my_md5.ComputeHash(mang);
                foreach (byte b in mang)
                {
                    str_md5 += b.ToString("x2");
                }
                return str_md5;
            }
            /// <summary>
            /// Get IdAccount đang login
            /// Author       :   QuyPN - 26/05/2018 - create
            /// </summary>
            /// <returns>
            /// IdAccount nếu tồn tại, trả về 0 nếu không tồn tại
            /// </returns>
            public static int GetIdAccount()
            {
                try
                {
                    var cookieToken = HttpContext.Current.Request.Cookies["token"];
                    if (cookieToken == null)
                    {
                        return 0;
                    }
                    var base64EncodedBytes = System.Convert.FromBase64String(HttpUtility.UrlDecode(cookieToken.Value));
                    string token = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    DataContext context = new DataContext();
                    TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                    if (tokenLogin == null)
                    {
                        return 0;
                    }
                    return tokenLogin.Account.Id;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}