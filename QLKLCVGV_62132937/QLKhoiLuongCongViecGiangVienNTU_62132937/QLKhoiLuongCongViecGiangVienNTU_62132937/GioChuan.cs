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
    
    public partial class GioChuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioChuan()
        {
            this.GiaoViens = new HashSet<GiaoVien>();
        }
    
        public string MaChucDanh { get; set; }
        public string TenChucDanh { get; set; }
        public Nullable<int> SoGioChuan { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}