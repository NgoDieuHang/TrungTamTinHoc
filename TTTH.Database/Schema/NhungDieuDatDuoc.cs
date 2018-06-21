using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("NhungDieuDatDuoc")]
    public partial class NhungDieuDatDuoc : TableHaveLang
    {
        [Required]
        [StringLength(255)]
        public string Icon { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public bool IsShow { set; get; }
    }
}
