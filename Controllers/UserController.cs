using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo34_Project.Models;
using Demo34_Project.App_Code;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Demo34_Project.Controllers
{
    [AuthorizeUserSession]
    public class UserController : Controller
    {
        Demo_Project_DBEntities1 db= new Demo_Project_DBEntities1();
        //Demo_Project_DBEntities db = new Demo_Project_DBEntities();
        // GET: User
        public ActionResult Dashboard()
        {
            /*if (Session["uid"] == null)
                return RedirectToAction("Login","General");*/ //itna code user ke hr actionmethod pr call karna padega jisse user userzone ke kisi bhi page jo exis nahi kr payega bina login ke agar wo soche ki url me action method ka name de de to waha se ab nahi hoga.
            ShowUserPicAndName();
            return View();
        }
        //[AuthorizeUserSession]  perticuler kisi action method ko lock karna h.
        [HttpGet]
        public ActionResult SubmitAssignment()
        {
            ShowUserPicAndName();
            return View();
        }
        [HttpPost]
        public ActionResult SubmitAssignment(UploadManager um)
        {
            ShowUserPicAndName();
            string msg = "";
            try
            {
                HttpPostedFileBase assignFile = Request.Files["AssignmentFile"];
                FileManager fm = new FileManager();
                fm.PostedFile = assignFile;
                fm.FolderName = "Students Uploaded Assignments";
                fm.AllowedExtensions = new string[] { ".JPEG", ".png", ".jpg", ".pdf", ".doc", ".docx", ".zip", ".rar" };
                fm.MaxAllowedFileSizeInKB = 4000;
                msg = fm.UploadMyFile();
                if(msg== "SUCCESS")
                {
                    um.Uploaded_BY = Session["uid"].ToString();
                    um.Upload_DT = DateTime.Now;
                    um.File_Name = fm.FileName;
                    um.Folder_Name = fm.FolderName;
                    um.File_Size_In_KB = fm.FileSizeInKB;
                    um.File_Type = fm.FileExtension;
                    um.Is_Del = false;
                    db.UploadManagers.Add(um);
                    db.SaveChanges();
                    msg = "Assignment uploaded successfully.";
                }
            }
            catch
            {
                msg = "Sorry! Unable to upload assignment.";
            }
            ViewBag.Message = msg;
            return View();
        }
        [HttpGet]
        public ActionResult DownloadAssignmentSolution()
        {
            ShowUserPicAndName();
            List<UploadManager> LstUM = db.UploadManagers.OrderByDescending(x => x.Upload_DT).ToList();
            return View(LstUM);
        }
        public FileResult Download(string FolderName,string FileName)
        {
            string path = Server.MapPath("~/Content/"+FolderName+"/"+FileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream",FileName);
        }
        [HttpGet]
        public ActionResult UserProfile()
        {
            string uid = Session["uid"].ToString();
            UserMaster um = db.UserMasters.Find(uid);
            ShowUserPicAndName();
            BindCityAndAreaInDDL();
            return View(um);
        }
        
        [HttpPost]
        public ActionResult UserProfile(UserMaster um)
        {
            HttpPostedFileBase NewImageFile = Request.Files["New_Pic"];
            FileManager fm = new FileManager();
            fm.AllowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
            fm.FolderName = "User_Profile_Pics";
            fm.MaxAllowedFileSizeInKB = 150;
            fm.PostedFile = NewImageFile;
            string msg = fm.UploadMyFile();
            UserMaster umdb = db.UserMasters.Find(um.EmailId);
            if(msg=="SUCCESS")
            {
                umdb.Picture_File_Name = fm.FileName;

            }
            if(msg=="Please choose a file." || msg=="SUCCESS")
            {
                umdb.Name = um.Name;
                umdb.Gender = um.Gender;
               
                umdb.Address = um.Address;
                umdb.Related_City_Id=um.Related_City_Id;
                umdb.Related_Area_Id=um.Related_Area_Id;
                umdb.MobileNo = um.MobileNo;
                db.Entry(umdb);
                db.SaveChanges();
                msg = "Your profile updated successfully.";
            }
            ShowUserPicAndName();
            BindCityAndAreaInDDL();
            ViewBag.Message = msg;
            UserMaster umNew = db.UserMasters.Find(um.EmailId);

            return View(umNew);
        }

        [NonAction]
        void BindCityAndAreaInDDL()
        {
            string userid = Session["uid"].ToString();
            UserMaster um = db.UserMasters.Find(userid);
            //for city
            ViewBag.Related_City_Id = db.CityMasters.ToList().Select(x => new SelectListItem()
            {
                Value = x.City_Id.ToString(),
                Text = x.City_Name,
                Selected = x.City_Id == um.Related_City_Id ? true : false
            }) ;
            //for area
            ViewBag.Related_Area_Id = db.AreaMasters.Where(x => x.Related_City_Id == um.Related_City_Id).ToList().Select(x => new SelectListItem()
            {
                Value = x.Area_Id.ToString(),
                Text = x.Area_Name,
                Selected = x.Area_Id == um.Related_Area_Id ? true : false

            });
        }
        public JsonResult GetAreaUsingAJAX(int CityId)
        {
            db.Configuration.ProxyCreationEnabled = false; //yaha pr data banta rahata h use rokne ke liye hun confifuration ki ProxyCreationEnabled ko false karna padta h jisse bar bar data nahi banega or table me add ho jayega jayada data aane pr ye nahi add kara pata h bar bar data aane pr. Dropdown karte time ye jaruri h
            List<AreaMaster> LstArea = db.AreaMasters.Where(am => am.Related_City_Id == CityId).ToList();
            return Json(LstArea, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            ShowUserPicAndName();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string Pass, string NewPass, string ConfNewPass)
        {
            string msg = "";
            if (NewPass == ConfNewPass)
            {
                string uid = Session["uid"].ToString();
                LoginMaster lm = db.LoginMasters.Find(uid);
                Cryptography cg=new Cryptography();
                string DecrPass = cg.DecryptMyData(lm.User_Password);
                if(Pass == DecrPass)
                {
                    string EncrPass = cg.EncryptMyData(NewPass);
                    lm.User_Password= EncrPass;
                    db.Entry(lm);
                    db.SaveChanges();
                    msg = "Password Changed Successfully";
                }
            }
            else
            {
                msg = "New password and confirm new pass must be same";
            }
            ViewBag.Message = msg;

            ShowUserPicAndName();
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Remove("uid");
            Session.Abandon();
            return RedirectToAction("/","General");

        }

        [HttpGet]
        public ActionResult Feedback()
        {
            ShowUserPicAndName();
            return View();
        }

       // To save feedback using ajax
        public JsonResult SaveFeedback(FeedbackMaster fm)
        {
            string msg = "";
            DateTime curTime = DateTime.Now;
            string userid = Session["uid"].ToString();
            try {
                fm.Submitted_By= userid;
                fm.Submitted_On = curTime;
                db.FeedbackMasters.Add(fm);
                db.SaveChanges();
                msg = "Your Feedback Submitted Successfully";
            } catch {
                msg = "we are unable to receive your feedback , please try again later";
            }
            return Json(msg,JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        void ShowUserPicAndName()
        {
            //UserMaster um = db.UserMasters.Find(Session["uid"].ToString());
            string userid = Session["uid"].ToString();
            UserMaster um = db.UserMasters.Find(userid);
            if (um.Picture_File_Name != null)    //null nahi h to anader aayega yani ki kux na kus h. null hoga to else id ke pass jayega.
                ViewBag.UserPicName = um.Picture_File_Name;
            else if (um.Gender.ToUpper() == "MALE")
                ViewBag.UserPicName = "male.png";
            else
                ViewBag.UserPicName = "female.png";
            ViewBag.UserName = um.Name;
        }
    }
}