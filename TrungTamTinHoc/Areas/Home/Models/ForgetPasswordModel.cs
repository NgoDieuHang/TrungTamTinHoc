using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TTTH.Common;
using TTTH.DataBase;
using TblAccount = TTTH.DataBase.Schema.Account;

namespace TrungTamTinHoc.Areas.Home.Models
{
    public class ForgetPasswordModel
    {
        private DataContext context;
        public ForgetPasswordModel()
        {
            context = new DataContext();
        }
        public ResponseInfo CheckAccountForgetPass(string email)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblAccount taiKhoan = context.Account.FirstOrDefault(x => x.Email == email && !x.DelFlag && x.IsActived);
                if (taiKhoan == null)
                {
                    result.Code = 208;
                    result.MsgNo = 39;
                }
                else
                {
                    string newpass = Common.newPassword();
                    taiKhoan.Password = Common.GetMD5(newpass);
                    context.SaveChanges();
                    transaction.Commit();
                    result.Code = 200;
                    string body = "<p> Chào mừng bạn đến với IPRO </p> <br>  <p>mật khẩu mới của bạn là : <b> " + newpass + " </b> </p>";
                    
                    if (!EmailService.Send(email, "Lấy lại mật khẩu", body))
                    {
                        result.MsgNo = 38;
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
    }
}