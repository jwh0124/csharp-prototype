using System;
using System.IO;
using System.Text;

namespace WiegandRead
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a temporary file, and put some data into it.
            string path = "/dev/wiegand";
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            // Open the stream and read it back.
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }
    }
}
