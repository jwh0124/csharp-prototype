using System.Runtime.InteropServices;

namespace MarshalExample
{
	public class CParam
	{
        [MarshalAs(UnmanagedType.LPStr)]
        public string? firstName;

        [MarshalAs(UnmanagedType.LPStr)]
        public string? lastName;
    }
}

