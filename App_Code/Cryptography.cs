using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Demo34_Project.App_Code
{
    public class Cryptography
    {
        /*internal string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        internal string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }*/

        string PlainText, CyperText;
        char ch;
        int ASCII_Value;
        internal string EncryptMyData(string NormalText)
        {
            CyperText = string.Empty;
            foreach(char c in NormalText)
            {
                ASCII_Value = c;
                if (ASCII_Value >= 65 && ASCII_Value <= 90)
                    ASCII_Value = ASCII_Value + 97 - 65;
                else if (ASCII_Value >= 97 && ASCII_Value <= 122)
                    ASCII_Value = 97 - ASCII_Value + 90;
                else if (ASCII_Value >= 48 && ASCII_Value <= 57)
                    ASCII_Value = 57 - ASCII_Value + 48;
                ch = (char)ASCII_Value;
                CyperText = CyperText + ch;
            }
            return CyperText;
        }
        internal string DecryptMyData(string EncryptedText)
        {
            PlainText = string.Empty;
            foreach(char c in EncryptedText)
            {
                ASCII_Value = c;    //Getting ascii from char
                if (ASCII_Value >= 65 && ASCII_Value <= 90)
                    ASCII_Value = 65 - ASCII_Value + 122;
                else if (ASCII_Value >= 97 && ASCII_Value <= 122)
                    ASCII_Value = ASCII_Value + 65 - 97;
                else if (ASCII_Value >= 48 && ASCII_Value <= 57)
                    ASCII_Value = 57 - ASCII_Value + 48;
                ch = (char)ASCII_Value;
                PlainText = PlainText + ch;
            }
            return PlainText;
        }
    }
}