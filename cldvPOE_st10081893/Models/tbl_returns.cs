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
    
    public partial class tbl_returns
    {
        public int returnID { get; set; }
        public Nullable<int> rentalID { get; set; }
        public Nullable<System.DateTime> returnDate { get; set; }
        public Nullable<int> elapsedDate { get; set; }
        public Nullable<double> fine { get; set; }
    
        public virtual tbl_rental tbl_rental { get; set; }
    }
}
