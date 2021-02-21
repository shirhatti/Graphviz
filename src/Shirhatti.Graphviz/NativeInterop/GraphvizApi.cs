using System;
using System.Runtime.InteropServices;

namespace Shirhatti.Graphviz.NativeInterop
{
    internal static class GraphvizApi
    {
        private const string GVC = "gvc";

        [DllImport(GVC, EntryPoint = "gvcVersion", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr GvcVersion(GraphvizHandle gvc);

        [DllImport(GVC, EntryPoint = "gvcBuildDate", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr GvcBuildDate(GraphvizHandle gvc);

        [DllImport(GVC, EntryPoint = "gvContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GvContext();

        [DllImport(GVC, EntryPoint = "gvFreeContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GvFreeContext(IntPtr gvc);

        [DllImport(GVC, EntryPoint = "gvLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GvLayout(GraphvizHandle gvc, CgraphHandle cgraph, string engine);

        [DllImport(GVC, EntryPoint = "gvFreeLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GvFreeLayout(GraphvizHandle gvc, CgraphHandle cgraph);

        [DllImport(GVC, EntryPoint = "gvRenderData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GvRenderData(GraphvizHandle gvc, CgraphHandle cgraph, string format, out IntPtr result, out int length);
    }
}
