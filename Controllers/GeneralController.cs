using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo34_Project.Controllers;
using Demo34_Project.App_Code;
using Demo34_Project.Models;

namespace Demo34_Project.Controllers
{
    public class GeneralController : Controller
    {
        Demo_Project_DBEntities1 db = new Demo_Project_DBEntities1();
        //Demo_Project_DBEntities db = new Demo_Project_DBEntities();
        static HumenDetection.CaptchaDetails cd;
        HumenDetection hd = new HumenDetection();
        // GET: General
        [HttpGet]
        public ActionResult Index()
        {
            // Testing Email Sender Start
            /*MyEmailSender es = new MyEmailSender();
            es.SendTo = "shreyaa06singh@gmail.com,erakashrathaur9554@gmail.com,rathore9554@gmail.com";
            es.Subject = "Test Email from KSS Chitrakoot.";
            es.Message = "Hello Akash, How are you? I hope you are doing well.";
            bool b = es.SendEmail();*/
             //Testing Email Sender End

            // Testing Password Encrypt and Decrypt Start
            /*Cryptography cg = new Cryptography();
            string et=cg.EncryptMyData("RamJEE@125");
            string pt = cg.DecryptMyData(et); */
            // Testing Password Encrypt and Decrypt End
            return View();
        }
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Pathology()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PrivateWard()
        {
            return View();
        }
        public ActionResult XRAY()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            BindCitiesInDDL();
            GenerateCaptcha();
            return View();
          
        }
        [HttpPost]
        public ActionResult Registration(UserMaster um, string Pass, string ConfPass, string CaptchaCode)
        {
            string msg = "";
            try
            {
                if (cd.CaptchaCode == CaptchaCode)
                {
                    if (Pass == ConfPass)
                    {
                        //To validate file
                        HttpPostedFileBase userfile = Request.Files["UserPic"];
                        FileManager fm = new FileManager();
                        fm.PostedFile = userfile;
                        fm.AllowedExtensions = new string[] { ".jpg", ".png", ".jpeg", ".jfif" };
                        fm.FolderName = "User_Profile_Pics";
                        msg = fm.UploadMyFile(); //validate & upload
                        if (msg == "SUCCESS" || msg== "Please choose a file.")
                        {
                            //database code
                            um.DateTime_of_Reg = DateTime.Now;
                            um.Is_Del = false;
                            if(msg=="SUCCESS")
                            um.Picture_File_Name = fm.FileName;
                            db.UserMasters.Add(um);
                            //setting login info
                            Cryptography cg = new Cryptography();
                            string EncryptedPass = cg.EncryptMyData(Pass);
                            LoginMaster lm = new LoginMaster();
                            lm.UserId = um.EmailId;//PK of regtbl
                            //lm.User_Password = Pass;
                            lm.User_Password = EncryptedPass;
                            lm.User_Status = true;      //ye humko false karna h
                            lm.Login_Count = 0;
                            lm.User_Type = "USER";    //"ADMIN" or "SELLER kux kis zone se kar rahe h registration tab esa karna h."
                            db.LoginMasters.Add(lm);
                            db.SaveChanges();
                            msg = "Congratulatuions! you are registered successfully.";
                            //To send Email Alert
                            MyEmailSender es = new MyEmailSender();
                            es.SendTo = um.EmailId;
                            es.Subject = "Welcome to Demo Project";
                            es.Message = "Hello " + um.Name + ",Welcome to Demo Project. You are successfully registerd in our web portal. \nYour user id is: " + um.EmailId + " and Password is: " + Pass + "\n\nRegrads\n\nTeam Demo Project";
                            es.SendEmail();

                        }
                    }
                    else
                    {
                        msg = "Password and confirm password must be same.";
                    }
                }
                else
                {
                    msg = "Invalid Captcha Code. Please try again.";
                }
            }
            catch
            {
                msg = "Due to some technical issue; we are unable to create your account right now.";
            }
            BindCitiesInDDL();
            GenerateCaptcha();
            ViewBag.Message = msg;
            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginMaster lm)
        {
            string msg = "";
            /*LoginMaster lmdb = db.LoginMasters.Find(lm.UserId);
            if (lmdb!=null)
            {
                if(lmdb.User_Password==lm.User_Password)
                {
                    if(lmdb.User_Type==lm.User_Type)
                    {
                        return RedirectToAction("Dashboard", "User");
                    }
                    else
                    {
                        msg = "Invalid User Type. Please try again.";
                    }
                }
                else
                {
                    msg = "Invalid Password please try again.";
                }
            }
            else
            {
                msg = "Invalid User Id. Please try again.";
            }
            ViewBag.Message = msg; For Single Record ke liye.*/  
            //LoginMaster lmdb = db.LoginMasters.SingleOrDefault(x => x.UserId == lm.UserId && x.User_Password == lm.User_Password && x.User_Type == lm.User_Type);
            LoginMaster lmdb = db.LoginMasters.SingleOrDefault(x => x.UserId == lm.UserId && x.User_Type == lm.User_Type);
            if (lmdb != null)
            {
                Cryptography cg = new Cryptography();
                string DecryptedPass = cg.DecryptMyData(lmdb.User_Password);
                if (lm.User_Password == DecryptedPass)
                {
                    if (lmdb.User_Status == true)
                    {
                        //Create log of login in table
                        lmdb.Last_Login_DateTime = DateTime.Now;
                        lmdb.Login_Count = lmdb.Login_Count + 1;
                        db.Entry(lmdb);
                        db.SaveChanges();
                        if (lmdb.User_Type == "USER")
                        {
                            Session["uid"] = lmdb.UserId;//pk
                            return RedirectToAction("Dashboard", "User");
                        }
                        else
                        {
                            Session["aid"] = lmdb.UserId;//pk
                            return RedirectToAction("Dashboard", "Admin");
                        }
                    }
                    else
                    {
                        msg = "Sorry! Your account is suspended.";
                    }
                }
                else
                    msg = "Invalid Password. please try again.";
            }
            else
            {
                //msg = "Invalid UserId or password.";
                msg = "Invalid UserId or User Type.";
            }
            ViewBag.Message = msg;
            return View();
        }
        [NonAction]
        void BindCitiesInDDL()
        {
            ViewBag.Related_City_Id = db.CityMasters.ToList().Select(x => new SelectListItem()
            {
                Value = x.City_Id.ToString(),
                Text = x.City_Name
            });
        }
        public JsonResult GetAreaUsingAJAX(int CityId)
        {
            db.Configuration.ProxyCreationEnabled = false; //yaha pr data banta rahata h use rokne ke liye hun confifuration ki ProxyCreationEnabled ko false karna padta h jisse bar bar data nahi banega or table me add ho jayega jayada data aane pr ye nahi add kara pata h bar bar data aane pr. Dropdown karte time ye jaruri h
            List<AreaMaster> LstArea = db.AreaMasters.Where(am => am.Related_City_Id == CityId).ToList();
            return Json(LstArea, JsonRequestBehavior.AllowGet);
        }
        [NonAction]
        void GenerateCaptcha()
        {
            cd = hd.GenerateNewCaptcha();
            ViewBag.Img = cd.FolderName + "/" + cd.CaptchaImageName;
        }
        //to get new captcha image using Ajax
        public JsonResult GetnewCaptchaImage()
        {
            GenerateCaptcha();
            string s = "/Content/" + cd.FolderName + "/" + cd.CaptchaImageName;
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}