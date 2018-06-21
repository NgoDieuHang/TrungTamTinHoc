using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("TinTuc")]
    public partial class TinTuc : TableHaveIdInt
    {
        public TinTuc()
        {
            CommentTinTuc = new HashSet<CommentTinTuc>();
            DanhGiaTinTuc = new HashSet<DanhGiaTinTuc>();
            TinTucTrans = new HashSet<TinTucTrans>();
        }

        [Required]
        [StringLength(255)]
        public string BeautyId { get; set; }

        public int SoLuongView { get; set; }

        [Required]
        [StringLength(255)]
        public string AnhMinhHoa { get; set; }
        
        public virtual ICollection<CommentTinTuc> CommentTinTuc { get; set; }
        
        public virtual ICollection<DanhGiaTinTuc> DanhGiaTinTuc { get; set; }
        
        public virtual ICollection<TinTucTrans> TinTucTrans { get; set; }
    }
}
