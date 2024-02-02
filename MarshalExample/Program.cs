using System.Runtime.InteropServices;
using MarshalExample;

class Program
{
    const string dllName = "Example.dll";

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Sum(int firstValue, int secondValue);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern string FullName(nint pParam);

    private static void Main(string[] args)
    {
        Console.WriteLine("Start Marshalling");

        int sumResult = Sum(1, 2);

        Console.WriteLine("1 + 2 = {sumResult}", sumResult);

        CParam cParam = new() { firstName="Circle", lastName="Jung" };

        IntPtr cParamPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CParam)));

        Marshal.StructureToPtr(cParam, cParamPtr, false);

        string fullName = FullName(cParamPtr);

        Marshal.FreeHGlobal(cParamPtr);

        Console.WriteLine("Full name : {fullName}", fullName);

        Console.WriteLine("Stop Marshalling");
    }
}