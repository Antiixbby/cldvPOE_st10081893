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
    
    public partial class tbl_car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_car()
        {
            this.tbl_rental = new HashSet<tbl_rental>();
        }
    
        public string carID { get; set; }
        public Nullable<int> modelInfoID { get; set; }
        public string available { get; set; }
        public Nullable<int> kilometersTravelled { get; set; }
        public Nullable<int> serviceKilometers { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_rental> tbl_rental { get; set; }
        public virtual tbl_modelInfo tbl_modelInfo { get; set; }
    }
}
