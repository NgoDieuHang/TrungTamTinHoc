using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Account")]
    public partial class Account : TableHaveIdInt
    {
        public Account()
        {
            GroupOfAccount = new HashSet<GroupOfAccount>();
            TokenLogin = new HashSet<TokenLogin>();
        }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string IdFacebook { get; set; }

        [StringLength(50)]
        public string IdGoogle { get; set; }

        [StringLength(100)]
        public string TokenActive { get; set; }

        public bool IsActived { get; set; }

        public int IdUser { get; set; }

        public int SoLanDangNhapSai { get; set; }

        public DateTime KhoaTaiKhoanDen { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<GroupOfAccount> GroupOfAccount { get; set; }

        public virtual ICollection<TokenLogin> TokenLogin { get; set; }
    }
}
