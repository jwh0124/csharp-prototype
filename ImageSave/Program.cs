using ImageSave.Common;
using System;

namespace ImageSave
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\CUBOX\\Etc\\whjung.jpg";
            string writePath = "C:\\test";

            ImageUtil util = new ImageUtil();
            string base64 = util.ImageConvertToBase64(path);

            util.Base64ConvertToImage(base64, writePath, Guid.NewGuid().ToString() + ".jpg");
        }
    }
}
