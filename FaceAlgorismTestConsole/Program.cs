using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FaceAlgorismTestConsole
{

    class Program
    {
        [DllImport("CUFaceRecognizer.dll", CallingConvention =CallingConvention.Cdecl)]
        public static extern IntPtr CreateCURecognizer();

        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool Init(IntPtr pRecognizer, StringBuilder config, bool initAsync);

        //Recognizer 삭제
        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeCURecognizer(IntPtr pRecognizer);

        public static void Main(string[] args)
        {
            IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
            FaceAlgorism algorism = new FaceAlgorism(_cache);
            FaceEmbeddingCache faceEmbedding = new FaceEmbeddingCache(_cache, algorism);

            IntPtr pRecognizer = CreateCURecognizer();

            StringBuilder config_file = new StringBuilder();
            config_file.Append("E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\cuface_config.json");

            Init(pRecognizer, config_file, false);

            

            //faceEmbedding.EmbeddingCache(pRecognizer);

            Console.WriteLine("-------------------- Matching Test -----------------------");
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            string testImagePath = "E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\test\\jung1.jpg";
            byte[] imageBytes = File.ReadAllBytes(testImagePath);

            algorism.FaceDetectionTest(pRecognizer, imageBytes);


            byte[] srcEmbed = algorism.FaceExtract(pRecognizer, imageBytes);

            /*List<FaceCache> faceCaches = new List<FaceCache>();
            _cache.TryGetValue("Face", out faceCaches);
            foreach (var item in faceCaches)
            {
                float score = algorism.FaceMatch(pRecognizer, srcEmbed, item.Value);
                Console.WriteLine("Score : " + score + " User No : " + item.No);
            }
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("-------------------- Matching Test -----------------------");*/

            DisposeCURecognizer(pRecognizer);
        }
    }
}
