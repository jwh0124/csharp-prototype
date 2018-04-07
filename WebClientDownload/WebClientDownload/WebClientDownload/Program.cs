using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;

namespace WebClientDownload
{
    class Program
    {
        static void Main(string[] args)
        {

            string targetPath = "http:\\\\192.168.0.192\\cardPrint\\EmpImage";
            string fileName = "12345.jpg";
            string savePath = "C:\\Test0823";
            string username = "administrator";
            string password = "shpa$$w0rd12";



            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            try
            {
                using (WebClient client = new WebClient())
                {
                    string filePath = targetPath + fileName;
                    var ur = new Uri(Uri.EscapeUriString(filePath.Replace(Path.DirectorySeparatorChar, '/'))).AbsoluteUri;
                    NetworkCredential myCreds = new NetworkCredential(username, password);
                    
                    client.Credentials = myCreds;
                    client.DownloadFile(ur, savePath + "\\" + fileName);
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
