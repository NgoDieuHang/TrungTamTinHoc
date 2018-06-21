using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ViTri")]
    public partial class ViTri : TableHaveIdInt
    {
        public ViTri()
        {
            ThongTinBoSung = new HashSet<ThongTinBoSung>();
        }

        [Required]
        [StringLength(50)]
        public string TenViTri { get; set; }

        [Required]
        [StringLength(500)]
        public string GhiChu { get; set; }
        
        public virtual ICollection<ThongTinBoSung> ThongTinBoSung { get; set; }
    }
}
