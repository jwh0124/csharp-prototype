using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace FaceUIPrototype
{
    class Program
    {
        const string cuLib = "libKFaceUI.so.1.0.0";
        static IntPtr qApp;
        static IntPtr mainUi;

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createQApp")]
        public static extern IntPtr createQApp();

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "execQApp")]
        public static extern int execQApp(IntPtr qApp);

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createUI")]
        public static extern IntPtr createUI();

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "showUI")]
        public static extern int showUI(IntPtr mainUi);

        [DllImport(cuLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "DisplayInit")]
        public static extern void DisplayInit();


        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DisplayInit));

            thread.Start();
            



            /*qApp = createQApp();

            Console.WriteLine("QApp :" + qApp);

            Thread thread = new Thread(new ThreadStart(qtApp));
            thread.Start();*/
        }

        /*public static void qtApp()
        {
            mainUi = createUI();
            Console.WriteLine("Main UI :" + mainUi);
            showUI(mainUi);

            int test = execQApp(qApp);
            Console.WriteLine("execQApplication" + test);
        }*/
    }
}
