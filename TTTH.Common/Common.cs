using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TTTH.DataBase;
using TTTH.DataBase.Schema;

namespace TTTH.Common
{
    /// <summary>
    /// Chứa các function sẽ sử dụng chung và nhiều lần trong dự án.
    /// Author       :   QuyPN - 06/05/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   TTTH.Common
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class Common
    {
        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi có thêm chuối khóa đầu và cuối.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa.
        /// </returns>
        public static string GetMD5(string str)
        {
            str = "TRUNGTAMTINHOC" + str + "TRUNGTAMTINHOC";
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);
            foreach (byte b in mang)
            {
                str_md5 += b.ToString("x2");
            }
            return str_md5;
        }
        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi không có thêm chuối khóa đầu và cuối.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa
        /// </returns>
        public static string GetSimpleMD5(string str)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);
            foreach (byte b in mang)
            {
                str_md5 += b.ToString("x2");
            }
            return str_md5;
        }
        /// <summary>
        /// Sinh chuỗi token ngẫu nhiên theo id account đăng nhập, độ dài mặc định 40 ký tự.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="id">
        /// id của account đăng nhập.
        /// </param>
        /// <param name="length">
        /// Dộ dài của token, mặc định 40 ký tự
        /// </param>
        /// <returns>
        /// Chuỗi token.
        /// </returns>
        public static string GetToken(int id, int length = 40)
        {
            string token = "";
            Random ran = new Random();
            string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (int i = 0; i < length; i++)
            {
                token += tmp.Substring(ran.Next(0, 63), 1);
            }
            token += id;
            return token;
        }
        /// <summary>
        /// Kiểm tra quyền truy cập một action trong controller.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="controller">
        /// controller cần kiểm tra.
        /// </param>
        /// <param name="action">
        /// action trong controller cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, string controller, string action)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Kiểm tra quyền truy cập một chức năng theo mã chức năng.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="idFunction">
        /// Mã chức năng cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, string idFunction)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Chuyển từ tiếng việt có dấu thành tiếng việt không dấu.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="s">
        /// Chuỗi tiếng việt cần chuyển.
        /// </param>
        /// <returns>
        /// Kết quả sau khi chuyển.
        /// </returns>
        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        /// <summary>
        /// Lấy dữ liệu từ cookies theo khóa, nếu không có dữ liệu thì trả về theo dữ liệu mặc định truyền vào hoặc rỗng
        /// Author          : QuyPN - 27/05/2018 - create
        /// </summary>
        /// <param name="key">Khóa cần lấy dữ liệu trong cookie</param>
        /// <param name="returnDefault">Kết quả trả về mặc định nếu không có dữ lieeujt rong cookie, mặc định là chuỗi rỗng</param>
        /// <returns>Giá trị lưu trữ trong cookie</returns>
        public static string GetCookie(string key, string returnDefault = "")
        {
            try
            {
                var httpCookie = HttpContext.Current.Request.Cookies[key];
                if (httpCookie == null)
                {
                    return returnDefault;
                }
                return Common.Base64Decode(HttpUtility.UrlDecode( httpCookie.Value));
            }
            catch
            {
                return returnDefault;
            }
        }
        /// <summary>
        /// Get IdAccount đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// IdAccount nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdAccount()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if(tokenLogin == null)
                {
                    return 0;
                }
                return tokenLogin.Account.Id;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Get IdUser của Account đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// IdUser nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdUser()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if (tokenLogin == null)
                {
                    return 0;
                }
                return tokenLogin.Account.IdUser;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Get Account đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// Account nếu tồn tại, trả về null nếu không tồn tại
        /// </returns>
        public static Account GetAccount()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if (tokenLogin == null)
                {
                    return null;
                }
                return tokenLogin.Account;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Get User đang login
        /// Author       :   QuyPN - 26/05/2018 - create
        /// </summary>
        /// <returns>
        /// User nếu tồn tại, trả về null nếu không tồn tại
        /// </returns>
        public static User GetUser()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now && !x.DelFlag);
                if (tokenLogin == null)
                {
                    return null;
                }
                return tokenLogin.Account.User;
            }
            catch
            {
                return null;
            }
        }
        public static string GetLang()
        {
            try
            {
                string lang = Common.GetCookie("lang", "vi");
                DataContext context = new DataContext();
                Language language = context.Language.FirstOrDefault(x => x.Id == lang && !x.DelFlag);
                if(language == null)
                {
                    return "vi";
                }
                return language.Id;
            }
            catch
            {
                return "vi";
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string newPassword()
        {
            string token = "";
            Random ran = new Random();
            string tmp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string tmp1 = "abcdefghijklmnopqrstuvwxyz";
            string tmp2 = "0123456789";
            token += tmp.Substring(ran.Next(0, 25), 1);
            for (int i = 0; i < 8; i++)
            {
                token += tmp1.Substring(ran.Next(0, 25), 1);
            }
            token += tmp2.Substring(ran.Next(0, 9), 1);

            return token;
        }
    }
}