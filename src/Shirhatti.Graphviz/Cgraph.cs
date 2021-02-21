using Shirhatti.Graphviz.NativeInterop;
using System;

namespace Shirhatti.Graphviz
{
    public class Cgraph : IDisposable
    {
        internal CgraphHandle Handle { get; }

        public Cgraph(string dot)
        {
            Handle = new CgraphHandle(CgraphApi.AgMemRead(dot));
        }

        public virtual void Dispose()
        {
            Handle.Dispose();
        }
    }
}
