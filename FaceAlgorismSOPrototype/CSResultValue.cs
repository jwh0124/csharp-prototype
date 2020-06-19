using System.Runtime.InteropServices;

namespace FaceAlgorismSOPrototype
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSResultValue
    {
        [MarshalAs(UnmanagedType.I4)]
        public int l, t, r, b;

        [MarshalAs(UnmanagedType.I4)]
        public int rows, cols;

        [MarshalAs(UnmanagedType.I4)]
        public int embedding_len;

        [MarshalAs(UnmanagedType.R4)]
        public float confidence;

        [MarshalAs(UnmanagedType.R4)]
        public float landmark_x1, landmark_y1, landmark_x2, landmark_y2, landmark_x3, landmark_y3, landmark_x4, landmark_y4, landmark_x5, landmark_y5;
    }
}
