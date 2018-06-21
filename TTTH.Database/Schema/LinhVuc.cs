using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LinhVuc")]
    public partial class LinhVuc : TableHaveIdInt
    {
        public LinhVuc()
        {
            ChuyenNganh = new HashSet<ChuyenNganh>();
            LinhVucTrans = new HashSet<LinhVucTrans>();
        }

        public virtual ICollection<ChuyenNganh> ChuyenNganh { get; set; }
        
        public virtual ICollection<LinhVucTrans> LinhVucTrans { get; set; }
    }
}
