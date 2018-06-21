using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TblUser = TTTH.DataBase.Schema.User;
using TblGroupOfAccount = TTTH.DataBase.Schema.GroupOfAccount;
using TblAccount = TTTH.DataBase.Schema.Account;
using TTTH.DataBase;
using TTTH.Validate;
using TTTH.Common;
using System.Data.Entity;

namespace TrungTamTinHoc.Areas.Home.Models
{
    public class RegisterModel
    {
        private DataContext context;
        public RegisterModel()
        {
            context = new DataContext();
        }
        public ResponseInfo TaoAccount(NewAccount newAccount)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblUser user = new TblUser
                {
                    Ho = newAccount.Ho,
                    Ten = newAccount.Ten,
                    Avatar = "http://2.bp.blogspot.com/-Fl8NZJZFq6w/U02LSHQ7iII/AAAAAAAAAHg/zpzikQfynpM/s1600/WAPHAYVL.MOBI-CONDAU+(11).gif",
                    GioiTinh = newAccount.GioiTinh,
                    NgaySinh = newAccount.NgaySinh,
                    SoDienThoai = "0167229145",
                    CMND = "192095142",
                    DiaChi = "Hue"
                };
                TblAccount account = new TblAccount
                {
                    Username = newAccount.Username,
                    Password = Common.GetMD5(newAccount.Password),
                    Email = newAccount.Email,
                    TokenActive = Common.GetToken(0),
                    IsActived = false,
                    SoLanDangNhapSai = 0,
                    KhoaTaiKhoanDen = DateTime.Now
                };
                account.GroupOfAccount.Add(new TblGroupOfAccount
                {
                    IdGroup = 3
                });
                user.Account.Add(account);
                context.User.Add(user);
                context.SaveChanges();
                transaction.Commit();
                SendEmailRegister(account);
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        public void SendEmailRegister(TblAccount account)
        {
            try
            {
                string lang = Common.GetLang();
                string content = "<p>Xin chào tài khoản " + account.Username + ".Vui lòng kích vào link: <a href='https://localhost:44339/home/confirm?username="+account.Username+ "&tokenactive="+account.TokenActive+"')>Tại đây</a></p>";
                EmailService.Send(account.Email, "Kích hoạt tài khoản", content);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckRegister(string username, string tokenactive)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                TblAccount account = context.Account.FirstOrDefault(x => x.Username == username && !x.DelFlag && x.TokenActive == tokenactive && !x.IsActived);
                if (account != null)
                {
                    account.IsActived = true;
                    context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception e)
            {
                transaction.Rollback();
                throw e;
            }
            
        }
    }
}