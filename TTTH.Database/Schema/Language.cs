using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Language")]
    public partial class Language : Table
    {
        [StringLength(5)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
