using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTTH.Common
{
    public class ResponseInfo
    {
        //200: Thành công
        //201: Validate sai
        //500: Lỗi Server
        //403: Không có quyền truy cập
        public int Code { get; set; }
        public int MsgNo { get; set; }
        public Dictionary<string, string> ListError { get; set; }
        public string ThongTinBoSung1 { get; set; }
        public string ThongTinBoSung2 { get; set; }
        public string ThongTinBoSung3 { get; set; }

        public ResponseInfo()
        {
            Code = 200;
            MsgNo = 0;
        }

    }
}