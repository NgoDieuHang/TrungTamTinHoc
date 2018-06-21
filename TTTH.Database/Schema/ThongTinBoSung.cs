using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ThongTinBoSung")]
    public partial class ThongTinBoSung : TableHaveIdInt
    {
        public ThongTinBoSung()
        {
            ThongTinBoSungTrans = new HashSet<ThongTinBoSungTrans>();
            User = new HashSet<User>();
        }

        public int IdViTri { get; set; }

        public bool LamDaiHan { get; set; }

        public virtual ViTri ViTri { get; set; }
        
        public virtual ICollection<ThongTinBoSungTrans> ThongTinBoSungTrans { get; set; }
        
        public virtual ICollection<User> User { get; set; }
    }
}
