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
    
    public partial class UploadManager
    {
        public int Upload_Id { get; set; }
        public string Title_of_File { get; set; }
        public string Description { get; set; }
        public string Uploaded_BY { get; set; }
        public string File_Name { get; set; }
        public string Folder_Name { get; set; }
        public string File_Type { get; set; }
        public Nullable<double> File_Size_In_KB { get; set; }
        public Nullable<System.DateTime> Upload_DT { get; set; }
        public Nullable<bool> Is_Del { get; set; }
    
        public virtual UserMaster UserMaster { get; set; }
    }
}