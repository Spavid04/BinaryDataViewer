using System;
using System.Runtime.InteropServices;

namespace DataViewer
{
    public static class Utils
    {
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl,
            SetLastError = false)]
        public static extern IntPtr Memcpy(IntPtr dest, IntPtr source, nint count);

        [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl,
            SetLastError = false)]
        public static extern IntPtr Memset(IntPtr dest, int value, nint count);
    }
}
