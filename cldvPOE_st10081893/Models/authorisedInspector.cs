//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cldvPOE_st10081893.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class authorisedInspector
    {
        public int authInspecID { get; set; }
        public Nullable<int> inspectorID { get; set; }
        public string password { get; set; }
    
        public virtual tbl_inspector tbl_inspector { get; set; }
    }
}
