using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ManHinh")]
    public partial class ManHinh : TableHaveIdString
    {
        public ManHinh()
        {
            ChucNang = new HashSet<ChucNang>();
            ManHinhTrans = new HashSet<ManHinhTrans>();
        }
        public int Order { get; set; }
        
        public virtual ICollection<ChucNang> ChucNang { get; set; }
        
        public virtual ICollection<ManHinhTrans> ManHinhTrans { get; set; }
    }
}
