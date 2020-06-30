using System;
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

            

        }
    }
}
