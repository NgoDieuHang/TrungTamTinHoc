using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTTH.Common
{
    /// <summary>
    /// Quản lý việc phân trang, lưu các tham số dùng cho việc phân trang của 1 danh sách.
    /// Author       :   QuyPN - 06/05/2018 - create
    /// </summary>
    public class Paging
    {
        public int CurrentPage { set; get; }
        public int TotalPages { set; get; }
        public int NumberOfRecord { set; get; }
        /// <summary>
        /// Hàm khởi tạo mặc định để gán các tham số mặc định khi khởi tạo 1 biến để lưu phân trang.
        /// Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        public Paging()
        {
            this.NumberOfRecord = 30;
            this.TotalPages = 1;
            this.CurrentPage = 1;
        }
        /// <summary>
        /// Hàm khởi tạo có các tham số để gán các tham số theo ý người khởi tạo.
        ///  Author       :   QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="TotalRecord">
        /// Tổng số hàng trong 1 bảng.
        /// </param>
        /// <param name="CurrenPage">
        /// Trang hiện tại đang hiển thị.
        /// </param>
        /// <param name="NumberOfRecord">
        /// Số hàng sẽ hiển thị trong 1 trang, mặc định là 30.
        /// </param>
        public Paging(int TotalRecord, int CurrenPage, int NumberOfRecord = 30)
        {
            this.NumberOfRecord = NumberOfRecord;
            this.TotalPages = TotalRecord / this.NumberOfRecord + (TotalRecord % this.NumberOfRecord > 0 ? 1 : 0);
            if (CurrenPage > this.TotalPages)
            {
                CurrenPage = this.TotalPages == 0 ? 1 : this.TotalPages;
            }
            if (CurrenPage < 1)
            {
                CurrenPage = 1;
            }
            this.CurrentPage = CurrenPage;
        }
    }
}