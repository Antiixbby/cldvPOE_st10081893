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
    
    public partial class tbl_rental
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_rental()
        {
            this.tbl_returns = new HashSet<tbl_returns>();
        }
    
        public int rentalID { get; set; }
        public string carID { get; set; }
        public Nullable<int> inspectorID { get; set; }
        public Nullable<int> driverID { get; set; }
        public Nullable<double> rentalFee { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
    
        public virtual tbl_car tbl_car { get; set; }
        public virtual tbl_driver tbl_driver { get; set; }
        public virtual tbl_inspector tbl_inspector { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_returns> tbl_returns { get; set; }
    }
}