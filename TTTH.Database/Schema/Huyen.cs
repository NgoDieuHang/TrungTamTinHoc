using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Huyen")]
    public partial class Huyen : Table
    {
        public Huyen()
        {
            Xa = new HashSet<Xa>();
        }

        [Key]
        [StringLength(3)]
        public string Id { get; set; }

        [Required]
        [StringLength(2)]
        public string IdTinh { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHuyen { get; set; }

        public virtual Tinh Tinh { get; set; }

        public virtual ICollection<Xa> Xa { get; set; }
    }
}
