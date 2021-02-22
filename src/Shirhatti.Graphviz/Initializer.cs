using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Shirhatti.Graphviz
{
    public class Initializer
    {
        private static string _graphVizBinPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                        "Graphviz", "bin"); 
        [ModuleInitializer]
        internal static void Initialize()
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
        }

        private static IntPtr TryLoadGraphvizBinary(string libraryName)
        {
            if (NativeLibrary.TryLoad(
                Path.Join(_graphVizBinPath, libraryName),
                out IntPtr handle))
            {
                return handle;
            }

            return default;
        }

        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (libraryName)
                {
                    case "gvc":
                        return TryLoadGraphvizBinary("gvc");
                    case "cgraph":
                        return TryLoadGraphvizBinary("cgraph");
                }
            }
            return default;
        }
    }
}
