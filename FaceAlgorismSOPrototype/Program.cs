using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FaceAlgorismSOPrototype
{
    class Program
    {

        const string cuLib = "libCUFaceRecognizer.so";

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateCURecognizer();

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool Init(IntPtr pRecognizer, StringBuilder config, bool initAsync);

        static void Main(string[] args)
        {
            Console.WriteLine("hi");

            IntPtr pRecognizer = CreateCURecognizer();

            StringBuilder config_file = new StringBuilder();
            config_file.Append("/home/cubox/algorism/cuface_config.json");

            bool InitResult = Init(pRecognizer, config_file, false);

            Console.WriteLine(pRecognizer);

            Console.WriteLine(InitResult);
        }
    }
}
