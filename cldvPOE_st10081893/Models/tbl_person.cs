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
    
    public partial class tbl_person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_person()
        {
            this.tbl_driver = new HashSet<tbl_driver>();
            this.tbl_inspector = new HashSet<tbl_inspector>();
        }
    
        public int personID { get; set; }
        public string personName { get; set; }
        public string emailAddr { get; set; }
        public string mobile { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_driver> tbl_driver { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_inspector> tbl_inspector { get; set; }
    }
}
