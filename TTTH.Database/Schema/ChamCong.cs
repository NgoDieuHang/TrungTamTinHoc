using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ChamCong")]
    public partial class ChamCong : TableHaveIdInt
    {
        public int IdUser { get; set; }

        public TimeSpan GioVaoLam { get; set; }

        public TimeSpan GioNghiLam { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLamViec { get; set; }

        public bool DaChamCong { get; set; }

        [Required]
        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual User User { get; set; }
    }
}
