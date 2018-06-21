using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("CommentTinTuc")]
    public partial class CommentTinTuc : TableHaveIdInt
    {
        public CommentTinTuc()
        {
            ChildComment = new HashSet<CommentTinTuc>();
        }

        public int? IdUser { get; set; }

        public int IdTinTuc { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public int? IdComment { get; set; }

        public virtual ICollection<CommentTinTuc> ChildComment { get; set; }

        public virtual CommentTinTuc ParentComent { get; set; }

        public virtual TinTuc TinTuc { get; set; }

        public virtual User User { get; set; }
    }
}
