using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Demo34_Project.App_Code
{
    public class FileManager
    {
        public HttpPostedFileBase PostedFile { get; set; }
        internal string FileName, FolderName, FileExtension;
        internal float FileSizeInKB, MaxAllowedFileSizeInKB;
        internal string[] AllowedExtensions;
        string Message;
        public FileManager()
        {
            FolderName = "UploadedFiles";
            AllowedExtensions = new string[] { ".JPG", ".JPEG", ".PNG", ".JFIF", ".PDF", ".DOC", ".DOCX", ".TXT", ".XLS", ".XALS", ".ZIP", ".RAR", ".PPT" };
            MaxAllowedFileSizeInKB = 1024;
        }
        string ValidateUploadedFile()
        {
            if (PostedFile.ContentLength > 0)
            {
                FileSizeInKB = PostedFile.ContentLength / 1024;
                if (FileSizeInKB <= MaxAllowedFileSizeInKB)
                {
                    FileExtension = PostedFile.FileName.Substring(PostedFile.FileName.LastIndexOf('.')).ToUpper();
                    bool Status = false;
                    foreach (string ext in AllowedExtensions)
                    {
                        if (ext.ToUpper() == FileExtension)
                        {
                            Status = true;
                            break;
                        }
                    }
                    if (Status == true)
                    {
                        Message = "SUCCESS";
                    }
                    else
                        Message = "Invalid file type.Please choose a valid file.";
                }
                else
                {
                    Message = "FIle size is too large. Max allowed size is: " + MaxAllowedFileSizeInKB + " KB";
                }
            }
            else
            {
                Message = "Please choose a file.";
            }
            return Message;
        }
        internal string UploadMyFile()
        {
            Message = ValidateUploadedFile();
            if (Message == "SUCCESS")
            {
                try
                {
                    FileName = Path.GetRandomFileName() + "_" + DateTime.Now.ToString("dd_MM_YY__hh_mm_ss") + PostedFile.FileName;  //ya to hum file ka extention likh sakte h + ke bad "" double code ke ander. 
                    string FolderPath = HttpContext.Current.Server.MapPath("~/Content/" + FolderName);
                    if (!Directory.Exists(FolderPath))
                    {
                        Directory.CreateDirectory(FolderPath);
                    }
                    PostedFile.SaveAs(FolderPath + "/" + FileName);
                    Message = "SUCCESS";

                }
                catch
                {
                    Message = "Sorry! unable to upload file.";
                }
            }
            return Message;
        }
    }

}