//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    using System;
    using System.Collections.Generic;
    
    public partial class GiangDay
    {
        public string MaGV { get; set; }
        public string MaLop { get; set; }
        public string MaMon { get; set; }
        public Nullable<int> SoSV { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }
    
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual Lop Lop { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}