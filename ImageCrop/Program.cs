using System;
using System.Drawing;
using System.IO;

namespace ImageCrop
{
    class Program
    {
        static void Main(string[] args)
        {
            string testImagePath = "E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\test\\jung1.jpg";
            byte[] imageBytes = File.ReadAllBytes(testImagePath);

            int cropWidth = 100;
            int cropHeight = 50;

            byte[] croppedImage = new byte[cropWidth * cropHeight];


            Bitmap bitmap = new Bitmap(testImagePath);
            Rectangle rectangle = new Rectangle(0, 0, 100, 100);
            Bitmap a = bitmap.Clone(rectangle, bitmap.PixelFormat);
            a.Save("E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\test\\jung10.jpg");
        }
    }
}
