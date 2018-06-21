using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ChucNang")]
    public partial class ChucNang : TableHaveIdString
    {
        public ChucNang()
        {
            ChucNangTrans = new HashSet<ChucNangTrans>();
            Permission = new HashSet<Permission>();
        }

        [Required]
        [StringLength(10)]
        public string IdScreen { get; set; }

        [Required]
        [StringLength(50)]
        public string ControllerName { get; set; }

        [Required]
        [StringLength(50)]
        public string ActionName { get; set; }

        public int Order { get; set; }

        public virtual ManHinh ManHinh { get; set; }

        public virtual ICollection<ChucNangTrans> ChucNangTrans { get; set; }
        
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
