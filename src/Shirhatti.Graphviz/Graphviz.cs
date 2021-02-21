using Shirhatti.Graphviz.NativeInterop;
using System;
using System.Runtime.InteropServices;

namespace Shirhatti.Graphviz
{
    public partial class Graphviz : IDisposable
    {
        private string _buildDate;
        private string _version;
        internal GraphvizHandle Handle { get; }

        public string BuildDate => _buildDate ??= Marshal.PtrToStringAnsi(GraphvizApi.GvcBuildDate(Handle));
        public string Version => _version ??= Marshal.PtrToStringAnsi(GraphvizApi.GvcVersion(Handle));
        public Graphviz()
        {
            Handle = new GraphvizHandle(GraphvizApi.GvContext());
        }
        public byte[] RenderDot(Cgraph cgraph, OutputFormat format)
        {
            _ = GraphvizApi.GvLayout(Handle, cgraph.Handle, "dot");
            _ = GraphvizApi.GvRenderData(Handle, cgraph.Handle, format.Value, out IntPtr result, out int length);
            
            byte[] image = new byte[length];
            Marshal.Copy(result, image, 0, length);

            _ = GraphvizApi.GvFreeLayout(Handle, cgraph.Handle);

            return image;
        }

        public virtual void Dispose()
        {
            Handle.Dispose();
        }
    }
}
