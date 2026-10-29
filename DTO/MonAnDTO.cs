using System;
using System.Collections.Generic;
using System.Text;

namespace CafePOS_5._3_.DTO
{
    public class MonAnDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = string.Empty;
        public int MaDanhMuc { get; set; }
        public decimal DonGia { get; set; }
        public string? TenDanhMuc { get; set; }
    }
}
