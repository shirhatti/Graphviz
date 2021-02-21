using Microsoft.Win32.SafeHandles;
using Shirhatti.Graphviz.NativeInterop;
using System;

namespace Shirhatti.Graphviz
{
    internal class GraphvizHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public GraphvizHandle(IntPtr handle) : base(true)
        {
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            _ = GraphvizApi.GvFreeContext(handle);
            return true;
        }
    }
}
