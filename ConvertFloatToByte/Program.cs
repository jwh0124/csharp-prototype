using System;
using System.Linq;

namespace ConvertFloatToByte
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] floatArray = new float[512];
            for (int i = 0; i < floatArray.Length; i++)
            {
                floatArray[i] = 1;
            }

            byte[] byteArray = new byte[2048];

            /*int x = 0;
            foreach (float f in floatArray)
            {
                byte[] t = BitConverter.GetBytes(f);
                for (int y = 0; y < 4; y++){
                    byteArray[y + x] = t[y];
                }
                    
                x += 4;
            }*/

            Buffer.BlockCopy(floatArray, 0, byteArray, 0, byteArray.Length);

            Console.Read();

        }
    }
}
