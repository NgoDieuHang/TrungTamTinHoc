using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using EntityFramework.Extensions;
using Newtonsoft.Json;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;
using Account = TrungTamTinHoc.Areas.Home.Models.Schema.Account;
using TblAccount = TTTH.DataBase.Schema.Account;
using TblTokenLogin = TTTH.DataBase.Schema.TokenLogin;
using TblUser = TTTH.DataBase.Schema.User;
using TblGroupOfAccount = TTTH.DataBase.Schema.GroupOfAccount;




namespace TrungTamTinHoc.Areas.Home.Models
{
    /// <summary>
    /// Xử lý các hoạt động tương tác với cơ sở dữ liệu trên trang login
    /// Author      :   HangNTD - 29/05/2018 - create
    /// </summary>
    /// <remarks>
    /// Package     :   Home.Models
    /// </remarks>
    public class LoginModel
    {
        private DataContext context;

        public LoginModel()
        {
            context = new DataContext();
        }
        /// <summary>
        /// Kiểm tra tài khoản này có được đăng nhập hay không
        /// Author:     HangNTD - 29/05/2018 - create
        /// </summary>
        /// <param name="account">Tài khoản cần kiểm tra của người dùng</param>
        /// <returns>Dữ liệu sau khi kiểm tra, nếu thành công thì trả về những thông tin cần thiết</returns>
        public ResponseInfo CheckAccount(Account account)
        {
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblAccount taiKhoan = context.Account.FirstOrDefault(x => x.Username == account.Username && !x.DelFlag);
                if (taiKhoan == null)
                {
                    taiKhoan = context.Account.FirstOrDefault(x => x.Email == account.Username && !x.DelFlag);
                }
                if (taiKhoan == null)
                {
                    result.Code = 202;
                    result.MsgNo = 28;
                }
                else
                {
                    if (taiKhoan.KhoaTaiKhoanDen > DateTime.Now)
                    {
                        result.Code = 203;
                        result.MsgNo = 29;
                        result.ThongTinBoSung1 = taiKhoan.KhoaTaiKhoanDen.ToString("HH:mm dd/MM/yyyy");
                    }
                    else
                    {
                        if (!taiKhoan.IsActived)
                        {
                            result.MsgNo = 30;
                            result.Code = 204;
                            //Thiếu code gửi mail
                        }
                        else
                        {
                            if (taiKhoan.Password!=Common.GetMD5(account.Password))
                            {
                                taiKhoan.SoLanDangNhapSai += 1;
                                result.ThongTinBoSung1 = taiKhoan.SoLanDangNhapSai + "";
                                result.MsgNo = 31;
                                if (taiKhoan.SoLanDangNhapSai == 5)
                                {
                                    taiKhoan.SoLanDangNhapSai = 0;
                                    taiKhoan.KhoaTaiKhoanDen = DateTime.Now.AddHours(1);
                                    result.MsgNo = 32;
                                    result.ThongTinBoSung1 = taiKhoan.KhoaTaiKhoanDen.ToString("HH:mm dd/MM/yyyy");
                                }
                                context.SaveChanges();
                                result.Code = 205;
                            }
                            else
                            {
                                taiKhoan.SoLanDangNhapSai = 0;
                                result.ThongTinBoSung1 = Common.GetToken(taiKhoan.Id);
                                context.TokenLogin.Add(new TblTokenLogin
                                {
                                    IdAccount = taiKhoan.Id,
                                    Token = result.ThongTinBoSung1,
                                    ThoiGianTonTai = DateTime.Now.AddDays(1)
                                });
                                context.SaveChanges();
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Xóa token trên cơ sở dữ liệu đồng thời xóa các token đã hết hạn tồn tại
        /// Author:     HangNTD - 29/05/2018 - create
        /// </summary>
        /// <param ></param>
        /// <returns>true nếu xóa thành công</returns>
        public bool RemoveToken()
        {
            try
            {
                string token = Common.GetCookie("token");
                context.TokenLogin.Where(x => x.Token == token).Delete();
                context.TokenLogin.Where(x => x.ThoiGianTonTai < DateTime.Now).Delete();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Lấy thông tin người dùng khi đăng nhập bằng facebook
        /// Author:     HangNTD - 29/05/2018 - create
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>Nếu thành công thì trả về những thông tin cần thiết</returns>
        public SocialAccount LayThongTinFB(string accessToken)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://graph.facebook.com/v3.0");
                HttpResponseMessage response = client.GetAsync($"me?fields=id,first_name,last_name,name,birthday,gender,email&access_token={accessToken}").Result;
                response.EnsureSuccessStatusCode();
                string fbInfo = response.Content.ReadAsStringAsync().Result;
                var jsonRes = JsonConvert.DeserializeObject<dynamic>(fbInfo);
                SocialAccount accountFB = new SocialAccount();
                accountFB.Id = jsonRes["id"] != null ? jsonRes["id"] : "";
                accountFB.FirstName = jsonRes["first_name"] != null ? jsonRes["first_name"] : "";
                accountFB.LastName = jsonRes["last_name"] != null ? jsonRes["last_name"] : "";
                accountFB.Name = jsonRes["name"] != null ? jsonRes["name"] : "";
                string birthday = jsonRes["birthday"] != null ? jsonRes["birthday"] : "";
                DateTime dateOfBirth = DateTime.Today;
                if (birthday.Length > 0 && birthday.Length == 4)
                {
                    dateOfBirth = new DateTime(Convert.ToInt32(birthday), 1, 1);
                }
                if (birthday.Length > 0 && birthday.Length == 10)
                {
                    dateOfBirth = new DateTime(Convert.ToInt32(birthday.Substring(6, 10)),
                        Convert.ToInt32(birthday.Substring(0, 2)),
                        Convert.ToInt32(birthday.Substring(3, 5))
                    );
                }
                accountFB.Birthday = dateOfBirth;
                accountFB.Email = jsonRes["email"] != null ? jsonRes["email"] : "";
                accountFB.Gender = jsonRes["gender"] != null ? jsonRes["gender"].ToString() == "male" ? true : false : true;
                return accountFB;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Xử lý các hoạt động tương tác với cơ sở dữ liệu trên trang login
        /// Author:     HangNTD - 29/05/2018 - create
        /// </summary>
        /// <param name="socialAccount">Tài khoản cần kiểm tra của người dùng khi đăng nhập bằng facebook hoặc google</param>
        /// <returns>Nếu thành công thì trả về những thông tin trong lớp token login</returns>
        public TblTokenLogin CheckSocialAccount(SocialAccount socialAccount, int type = 1)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                if (socialAccount.Id != "")
                {
                    TblAccount account = context.Account.FirstOrDefault(x => x.Email == socialAccount.Email && !x.DelFlag);
                    if (account == null)
                    {
                        account = context.Account.FirstOrDefault(x => ((type == 1 && x.IdFacebook == socialAccount.Id) || (type != 1 && x.IdGoogle == socialAccount.Id)) && !x.DelFlag);
                        if (account != null && socialAccount.Email != "")
                        {
                            account.Email = socialAccount.Email;
                        }
                    }
                    else
                    {
                        if (type == 1)
                        {
                            account.IdFacebook = socialAccount.Id;
                        }
                        else
                        {
                            account.IdGoogle = socialAccount.Id;
                        }
                    }
                    if (account == null)
                    {
                        TblUser user = new TblUser
                        {
                            Ho = socialAccount.FirstName,
                            Ten = socialAccount.LastName,
                            Avatar = "http://2.bp.blogspot.com/-Fl8NZJZFq6w/U02LSHQ7iII/AAAAAAAAAHg/zpzikQfynpM/s1600/WAPHAYVL.MOBI-CONDAU+(11).gif",
                            GioiTinh = socialAccount.Gender,
                            NgaySinh = socialAccount.Birthday,
                            SoDienThoai = socialAccount.PhoneNumber,
                            CMND = "",
                            DiaChi = ""
                        };
                        account = new TblAccount
                        {
                            Username = "",
                            Password = "",
                            Email = socialAccount.Email,
                            TokenActive = "",
                            IsActived = true,
                            SoLanDangNhapSai = 0,
                            KhoaTaiKhoanDen = DateTime.Now
                        };
                        if (type == 1)
                        {
                            account.IdFacebook = socialAccount.Id;
                        }
                        else
                        {
                            account.IdGoogle = socialAccount.Id;
                        }
                        account.GroupOfAccount.Add(new TblGroupOfAccount
                        {
                            IdGroup = 3
                        });
                        user.Account.Add(account);
                        context.User.Add(user);
                    }
                    account.SoLanDangNhapSai = 0;
                    account.Username = "Hang";
                    account.Password = "Hang1234";
                    //TblCauHinh cauHinh = context.CauHinh.FirstOrDefault(x => x.Id == 1);
                    TblTokenLogin tokenLogin = new TblTokenLogin
                    {
                        IdAccount = account.Id,
                        Token = Common.GetToken(account.Id),
                        ThoiGianTonTai = DateTime.Now.AddDays(1)
                        //ThoiGianTonTai = DateTime.Now.AddHours(cauHinh.ThoiGianTonTaiToken)
                    };
                    account.TokenLogin.Add(tokenLogin);
                    context.SaveChanges();
                    transaction.Commit();
                    return tokenLogin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        /// <summary>
        /// Lấy thông tin người dùng khi đăng nhập bằng google
        /// Author:     HangNTD - 29/05/2018 - create
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>Nếu thành công thì trả về những thông tin cần thiết</returns>
        public SocialAccount LayThongTinGG(string accessToken)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.googleapis.com/plus/v1/people/");
                HttpResponseMessage response = client.GetAsync($"me?access_token={accessToken}").Result;
                response.EnsureSuccessStatusCode();
                string ggInfo = response.Content.ReadAsStringAsync().Result;
                var jsonRes = JsonConvert.DeserializeObject<dynamic>(ggInfo);
                SocialAccount accountGG = new SocialAccount();
                accountGG.Id = jsonRes["id"] != null ? jsonRes["id"] : "";
                accountGG.FirstName = jsonRes.name.familyName != null ? jsonRes.name.familyName : "";
                accountGG.LastName = jsonRes.name.givenName != null ? jsonRes.name.givenName : "";
                accountGG.Name = jsonRes["displayName"] != null ? jsonRes["displayName"] : "";
                string birthday = jsonRes["birthday"] != null ? jsonRes["birthday"] : "";
                DateTime dateOfBirth = DateTime.Today;
                if (birthday.Length > 0 && birthday.Length == 4)
                {
                    dateOfBirth = new DateTime(Convert.ToInt32(birthday), 1, 1);
                }
                if (birthday.Length > 0 && birthday.Length == 10)
                {
                    dateOfBirth = new DateTime((Convert.ToInt32(birthday.Substring(0, 4))==0000)?0001: Convert.ToInt32(birthday.Substring(0, 4)),
                        Convert.ToInt32(birthday.Substring(5, 2)),
                        Convert.ToInt32(birthday.Substring(8, 2))
                    );
                }
                accountGG.Birthday = dateOfBirth;
                accountGG.Email = jsonRes.emails[0].value != null ? jsonRes.emails[0].value : "";
                accountGG.Gender = jsonRes["gender"] != null ? jsonRes["gender"].ToString() == "male" ? true : false : true;
                return accountGG;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}