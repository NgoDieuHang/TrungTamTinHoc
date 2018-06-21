using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("FileHoSo")]
    public partial class FileHoSo : TableHaveIdInt
    {
        public int? IdUser { get; set; }

        [StringLength(255)]
        public string LoaiFile { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        public virtual User User { get; set; }
    }
}
