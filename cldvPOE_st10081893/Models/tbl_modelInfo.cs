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
    
    public partial class tbl_modelInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_modelInfo()
        {
            this.tbl_car = new HashSet<tbl_car>();
        }
    
        public int modelInfoID { get; set; }
        public Nullable<int> manufacturerID { get; set; }
        public Nullable<int> bodyTypeID { get; set; }
        public string model { get; set; }
    
        public virtual tbl_bodyType tbl_bodyType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_car> tbl_car { get; set; }
        public virtual tbl_manufacturer tbl_manufacturer { get; set; }
    }
}
