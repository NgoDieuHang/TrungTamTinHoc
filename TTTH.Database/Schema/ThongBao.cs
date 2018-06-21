using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ThongBao")]
    public partial class ThongBao : TableHaveIdInt
    {
        public int IdUserNhan { get; set; }

        public int IdUserGui { get; set; }

        [Required]
        [StringLength(100)]
        public string TieuDe { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public bool DaDoc { get; set; }

        public virtual User UserGui { get; set; }

        public virtual User UserNhan { get; set; }
    }
}
