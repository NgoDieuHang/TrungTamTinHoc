using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("GroupTrans")]
    public partial class GroupTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        [Required]
        [StringLength(500)]
        public string MoTa { get; set; }

        public virtual Group Group { get; set; }
    }
}
