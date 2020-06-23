using System;
using System.Runtime.InteropServices;

namespace FaceUIPrototype
{
    public struct Tempdata
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string argument;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct TempAlldata
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Tempdata[] argv;

        [MarshalAs(UnmanagedType.I4)]
        public int argc;
    }
}
