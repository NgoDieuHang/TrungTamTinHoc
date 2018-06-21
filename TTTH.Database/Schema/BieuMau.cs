using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("BieuMau")]
    public partial class BieuMau : TableHaveLang
    {
        [Required]
        [StringLength(200)]
        public string TenBieuMau { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(1000)]
        public string GhiChu { get; set; }
    }
}
