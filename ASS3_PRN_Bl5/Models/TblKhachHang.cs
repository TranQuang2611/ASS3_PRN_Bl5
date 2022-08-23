using System;
using System.Collections.Generic;

#nullable disable

namespace ASS3_PRN_Bl5.Models
{
    public partial class TblKhachHang
    {
        public string MaKh { get; set; }
        public string TenKh { get; set; }
        public bool Gt { get; set; }
        public string Diachi { get; set; }
        public DateTime? NgaySinh { get; set; }
    }
}
