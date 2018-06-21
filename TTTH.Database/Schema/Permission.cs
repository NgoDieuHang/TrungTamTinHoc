using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Permission")]
    public partial class Permission : TableHaveIdInt
    {
        public int IdGroup { get; set; }

        [Required]
        [StringLength(10)]
        public string IdChucNang { get; set; }

        public bool IsEnable { get; set; }

        public virtual ChucNang ChucNang { get; set; }

        public virtual Group Group { get; set; }
    }
}
