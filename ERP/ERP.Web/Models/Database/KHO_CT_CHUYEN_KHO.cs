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
    
    public partial class KHO_CT_CHUYEN_KHO
    {
        public int ID { get; set; }
        public string SO_CHUNG_TU { get; set; }
        public string MA_HANG { get; set; }
        public string XUAT_TAI_KHO { get; set; }
        public string NHAP_TAI_KHO { get; set; }
        public string DVT { get; set; }
        public int SO_LUONG { get; set; }
    
        public virtual DM_KHO DM_KHO { get; set; }
        public virtual DM_KHO DM_KHO1 { get; set; }
        public virtual HH HH { get; set; }
        public virtual KHO_XUAT_KHO KHO_XUAT_KHO { get; set; }
    }
}
