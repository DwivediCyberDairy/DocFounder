//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo34_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AreaMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AreaMaster()
        {
            this.UserMasters = new HashSet<UserMaster>();
        }
    
        public int Area_Id { get; set; }
        public string Area_Name { get; set; }
        public Nullable<int> Related_City_Id { get; set; }
    
        public virtual CityMaster CityMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMaster> UserMasters { get; set; }
    }
}
