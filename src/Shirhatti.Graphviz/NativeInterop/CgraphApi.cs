using System;
using System.Runtime.InteropServices;

namespace Shirhatti.Graphviz.NativeInterop
{
    internal static class CgraphApi
    {
        private const string CGRAPH = "cgraph";

        [DllImport(CGRAPH, EntryPoint = "agmemread", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AgMemRead(string data);

        [DllImport(CGRAPH, EntryPoint = "agclose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AgClose(IntPtr g);
    }
}
