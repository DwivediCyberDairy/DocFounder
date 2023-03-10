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
    
    public partial class UserMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserMaster()
        {
            this.UploadManagers = new HashSet<UploadManager>();
            this.FeedbackMasters = new HashSet<FeedbackMaster>();
        }
    
        public string Name { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public Nullable<int> Related_City_Id { get; set; }
        public Nullable<int> Related_Area_Id { get; set; }
        public string Address { get; set; }
        public string Picture_File_Name { get; set; }
        public Nullable<System.DateTime> DateTime_of_Reg { get; set; }
        public Nullable<bool> Is_Del { get; set; }
    
        public virtual AreaMaster AreaMaster { get; set; }
        public virtual CityMaster CityMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UploadManager> UploadManagers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeedbackMaster> FeedbackMasters { get; set; }
    }
}
