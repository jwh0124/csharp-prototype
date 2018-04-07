using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace WebClientDownload
{
    class Program
    {
        static void Main(string[] args)
        {

            string targetPath = "http://192.168.0.192/cardPrint/EmpImage";
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
                    AutoResetEvent autoReset = new AutoResetEvent(false);
                    var ur = new Uri(targetPath + "/" + fileName);
                    NetworkCredential myCreds = new NetworkCredential(username, password);
                    client.Credentials = myCreds;
           
                    client.DownloadFileAsync(ur, savePath + "\\" + fileName);
                    autoReset.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
