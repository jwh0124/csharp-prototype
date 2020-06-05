using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FaceAlgorismTestConsole
{
    class Program
    {
        [DllImport("test.dll")]
        extern public static double Add(double a, double b);

        //[DllImport("CUFaceRecognizer.dll", CharSet =CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool Init(CUFaceRecognizer pRecognizer, StringBuilder configfile, bool initAsync);

        // 얼굴 추출
        //[DllImport("CUFaceRecognizer.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern ResultCode FaceExtraction(CUFaceRecognizer pRecognizer, StringBuilder jpgData, long imageLen,ref ResultValue retValue, bool isCropped = false);

        // 얼굴 매치(비교)
        //[DllImport("CUFaceRecognizer.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern float MatchFeature(CUFaceRecognizer pRecognizer, StringBuilder srcFeature, long srcFeatureLen, StringBuilder destFeature, long destFeatureLen);

        // Recognizer 삭제
        //[DllImport("CUFaceRecognizer.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern void DisposeCURecognizer(CUFaceRecognizer pRecognizer);


        static void Main(string[] args)
        {
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(3, 4));

        }
    }
}
