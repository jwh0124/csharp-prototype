using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FaceUIPrototype
{
    class Program
    {
        const string cuLib = "libKFaceUI.so.1.0.0";

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "DisplayInit")]
        public static extern void DisplayInit();

        static void Main(string[] args)
        {
            DisplayInit();
        }
    }
}
