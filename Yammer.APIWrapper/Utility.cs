using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace Yammer.APIWrapper
{
    public class Utility
    {
        public static Dictionary<string, DirectoryInfo> GetAppData()
        {
            Dictionary<string, DirectoryInfo> appData = new Dictionary<string, DirectoryInfo>();

            string appName = Yammer.APIWrapper.Configuration.ApplicationName;
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\" + appName;

            if (!Directory.Exists(path + "\\" + "Yammer\\Data"))
                Directory.CreateDirectory(path + "\\" + "Yammer\\Data");

            if (!Directory.Exists(path + "\\" + "Yammer\\Images"))
                Directory.CreateDirectory(path + "\\" + "Yammer\\Images");

            appData.Add("data", new DirectoryInfo(path + "\\" + "Yammer\\Data"));
            appData.Add("images", new DirectoryInfo(path + "\\" + "Yammer\\Images"));

            return appData;

        }

        public static object Deserialize(Type type, string xml)
        {

            XmlSerializer serializer = new XmlSerializer(type);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(xml);
            System.IO.MemoryStream stream = new MemoryStream(bytes);
            object obj = (object)serializer.Deserialize(stream);

            return obj;

        }

        // Create an md5 sum string of this string
        public static string GetMd5Sum(string str)
        {
            // First we need to convert the string into bytes, which
            // means using a text encoder.
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

            // Create a buffer large enough to hold the string
            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            // Now that we have a byte array we can ask the CSP to hash it
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            // Build the final string by converting each byte
            // into hex and appending it to a StringBuilder
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            // And return it
            return sb.ToString();
        }
    }
}
