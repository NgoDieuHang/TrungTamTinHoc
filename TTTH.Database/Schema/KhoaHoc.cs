using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("KhoaHoc")]
    public partial class KhoaHoc : TableHaveIdInt
    {
        public KhoaHoc()
        {
            CommentKhoaHoc = new HashSet<CommentKhoaHoc>();
            DanhGiaKhoaHoc = new HashSet<DanhGiaKhoaHoc>();
            KhoaHocTrans = new HashSet<KhoaHocTrans>();
            LopHoc = new HashSet<LopHoc>();
        }
        
        [Required]
        [StringLength(255)]
        public string BeautyId { get; set; }

        public int IdChuyenNganh { get; set; }

        public int SoLuongView { get; set; }

        public int SoLuongDaDangKy { get; set; }

        [Required]
        [StringLength(255)]
        public string AnhMinhHoa { get; set; }
        
        public virtual ICollection<CommentKhoaHoc> CommentKhoaHoc { get; set; }

        public virtual ChuyenNganh ChuyenNganh { get; set; }
        
        public virtual ICollection<DanhGiaKhoaHoc> DanhGiaKhoaHoc { get; set; }
        
        public virtual ICollection<KhoaHocTrans> KhoaHocTrans { get; set; }
        
        public virtual ICollection<LopHoc> LopHoc { get; set; }
    }
}
