using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Demo34_Project.App_Code
{
    public class HumenDetection
    {
        internal class CaptchaDetails
        {
            internal string CaptchaImageName, FolderName, CaptchaCode;
        }
        internal string GetRandomCode()
        {
            string Code = "";
            char ch;
            Random r = new Random();
            int x = r.Next(1, 10);
            if (x % 2 == 0)
            {
                ch = (char)r.Next(65, 90);
                Code = Code + ch;
            }
            ch = (char)r.Next(100, 120);
            Code = Code + ch;
            ch = (char)r.Next(70, 90);
            Code = Code + ch;
            ch = (char)r.Next(49, 57);
            Code = Code + ch;
            ch = (char)r.Next(105, 122);
            Code = Code + ch;
            ch = (char)r.Next(75, 90);
            Code = Code + ch;
            int n = r.Next(1, 6);
            if (n % 2 == 0)
            {
                ch = (char)r.Next(50, 57);
                Code = Code + ch;
            }
            n = r.Next(1, 50);
            if (n % 2 == 0)
            {
                ch = (char)r.Next(110, 120);
                Code = Code + ch;
            }
            return Code;

        }
        internal CaptchaDetails GenerateNewCaptcha()
        {
            CaptchaDetails cd = new CaptchaDetails();
            SolidBrush sbMaroon = new SolidBrush(Color.Maroon);
            Pen BluePen = new Pen(Color.Blue);
            Font f = new Font("Verdana", 16, FontStyle.Strikeout);
            Bitmap chart = new Bitmap(150, 40);
            Graphics g = Graphics.FromImage(chart);   //us chart ko field me laye h kisi table pr 
            // g us table ya field ka object h us pr sara work karege.
            g.Clear(Color.LightPink);
            g.DrawRectangle(BluePen, 2, 2, 144, 35);
            cd.CaptchaCode = GetRandomCode();
            g.DrawString(cd.CaptchaCode, f, sbMaroon, 20, 5);
            g.Flush();
            cd.CaptchaImageName = Path.GetRandomFileName() + ".jpg";
            cd.FolderName = "Captcha_Images";
            string FolderPath = HttpContext.Current.Server.MapPath("~/Content/" + cd.FolderName);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            chart.Save(FolderPath + "/" + cd.CaptchaImageName, ImageFormat.Jpeg);
            return cd;
        }


    }

}