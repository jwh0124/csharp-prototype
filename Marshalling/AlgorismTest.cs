using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorismTestWebApp
{
    public class AlgorismTest
    {
        public AlgorismTest()
        {
            IntPtr pRecognizer = CreateCURecognizer();

            StringBuilder config_file = new StringBuilder();
            config_file.Append("E:\\CUBOX\\Private\\CSharp\\AlgorismTestWebApp\\cuface_config.json");

            bool abc = Init(pRecognizer, config_file, false);
        }

        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateCURecognizer();

        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool Init(IntPtr pRecognizer, StringBuilder config, bool initAsync);
                
    }
}
