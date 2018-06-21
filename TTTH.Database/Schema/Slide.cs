using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Slide")]
    public partial class Slide : TableHaveLang
    {
        [Required]
        [StringLength(255)]
        public string LinkAnh { get; set; }

        [Required]
        [StringLength(100)]
        public string TieuDe { get; set; }

        [Required]
        [StringLength(1000)]
        public string ChiTiet { get; set; }

        [Required]
        [StringLength(255)]
        public string Link { get; set; }

        public bool HienThi { get; set; }
    }
}
