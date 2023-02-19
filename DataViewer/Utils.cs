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

        public static byte ByteFromLiteral(string text)
        {
            if (text.StartsWith("'"))
            {
                ReadOnlySpan<char> charLiteral = text.AsSpan(1, text.Length - 2);
                if (charLiteral.Length == 1 && charLiteral[0] != '\\')
                {
                    return (byte)charLiteral[0]; // i guess this works 🤷
                }
                else if (charLiteral.Length == 2 && charLiteral[0] == '\\')
                {
                    switch (charLiteral[1])
                    {
                        case '0': return (byte)'\0';
                        case '\'': return (byte)'\'';
                        case '\"': return (byte)'"';
                        case '\\': return (byte)'\\';
                        case 'a': return (byte)'\a';
                        case 'b': return (byte)'\b';
                        case 'f': return (byte)'\f';
                        case 'n': return (byte)'\n';
                        case 'r': return (byte)'\r';
                        case 't': return (byte)'\t';
                        case 'v': return (byte)'\v';
                        default: throw new ArgumentException($"Invalid escape sequence \"{charLiteral}\"");
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid char literal \"{charLiteral}\"");
                }
            }
            else
            {
                bool hex = false;
                if (text.ToLower().StartsWith("0x"))
                {
                    text = text.Substring(2);
                    hex = true;
                }

                if (text.ToLower().EndsWith("h"))
                {
                    text = text.Substring(0, text.Length - 1);
                    hex = true;
                }

                return Convert.ToByte(text, hex ? 16 : 10);
            }
        }
    }
}
