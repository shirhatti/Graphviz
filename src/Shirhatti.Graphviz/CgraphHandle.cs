using Microsoft.Win32.SafeHandles;
using Shirhatti.Graphviz.NativeInterop;
using System;

namespace Shirhatti.Graphviz
{
    internal class CgraphHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public CgraphHandle(IntPtr handle) : base(true)
        {
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            CgraphApi.AgClose(handle);
            return true;
        }
    }
}
