//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Web.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class QUY_PHIEU_THU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUY_PHIEU_THU()
        {
            this.QUY_CT_PHIEU_THU = new HashSet<QUY_CT_PHIEU_THU>();
        }
    
        public string SO_CHUNG_TU { get; set; }
        public System.DateTime NGAY_CHUNG_TU { get; set; }
        public System.DateTime NGAY_HACH_TOAN { get; set; }
        public string MA_DOI_TUONG { get; set; }
        public string LY_DO_NOP { get; set; }
        public string DIEN_GIAI_LY_DO_NOP { get; set; }
        public string NGUOI_NOP { get; set; }
        public string NHAN_VIEN_THU { get; set; }
        public string CHUNG_TU_KEM_THEO { get; set; }
        public decimal TONG_TIEN { get; set; }
        public string NGUOI_LAP_BIEU { get; set; }
    
        public virtual DM_DOI_TUONG DM_DOI_TUONG { get; set; }
        public virtual HT_NGUOI_DUNG HT_NGUOI_DUNG { get; set; }
        public virtual HT_NGUOI_DUNG HT_NGUOI_DUNG1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUY_CT_PHIEU_THU> QUY_CT_PHIEU_THU { get; set; }
    }
}
