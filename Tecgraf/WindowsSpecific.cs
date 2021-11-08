using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Tecgraf
{

    /*
    public static class WindowsVisualStyles
    {

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct ACTCTX
        {
            public int cbSize;
            public uint dwFlags;
            public string lpSource;
            public UInt16 wProcessorArchitecture;
            public UInt16 wLangId;
            public string lpAssemblyDirectory;
            public IntPtr lpResourceName;
            public string lpApplicationName;
            public IntPtr hModule;
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        extern static IntPtr CreateActCtxA(ref ACTCTX actctx);

        [DllImport("Kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ActivateActCtx(IntPtr hActCtx, out IntPtr lpCookie);

        public static void Enable()
        {
            ACTCTX ctx=new ACTCTX();
            ctx.cbSize = Marshal.SizeOf(typeof(ACTCTX));
            ctx.dwFlags = 4; // 28;
            ctx.lpSource = "shell32.dll";
            ctx.wProcessorArchitecture = 0;
            ctx.wLangId = 0;
            ctx.lpAssemblyDirectory = Environment.SystemDirectory;
            ctx.lpResourceName = (IntPtr)124;
            ctx.hModule = IntPtr.Zero;


            IntPtr cc = CreateActCtxA(ref ctx);

            

            int err=Marshal.GetLastWin32Error();

            IntPtr cookie;
            bool res=ActivateActCtx(cc, out cookie);


         }
    }*/

    [SuppressUnmanagedCodeSecurity]
    public static class WindowsSpecific
    {


        //Declare all the Dll Imports, these are C++ Dll's
        [DllImport("Kernel32.dll")]
        private extern static IntPtr CreateActCtx(ref ACTCTX actctx);
        [DllImport("Kernel32.dll")]
        private extern static bool ActivateActCtx(IntPtr hActCtx, ref IntPtr lpCookie);
        //Create a structure to hold Active Content 
        private struct ACTCTX
        {
            public int cbSize;
            public uint dwFlags;
            public string lpSource;
            public ushort wProcessorArchitecture;
            public ushort wLangId;
            public string lpAssemblyDirectory;
            public IntPtr lpResourceName;
            public string lpApplicationName;
            public IntPtr hModule;
        }





        public static bool EnableThemingInWindows()
        {

            

            ACTCTX actctx = new ACTCTX();
            actctx.cbSize = Marshal.SizeOf(actctx);
            actctx.dwFlags = 28;
            actctx.lpSource = "shell32.dll";
            actctx.wProcessorArchitecture = 0;
            actctx.wLangId = 0;
            actctx.lpAssemblyDirectory = Environment.SystemDirectory;
            actctx.lpResourceName = (IntPtr)124;
            actctx.hModule = IntPtr.Zero;

            int err = Marshal.GetLastWin32Error();

            IntPtr c = CreateActCtx(ref actctx);

            err = Marshal.GetLastWin32Error();
            IntPtr cookie = IntPtr.Zero;
            bool suc = ActivateActCtx(c, ref cookie);

            err=Marshal.GetLastWin32Error();

            return suc;
        }

        /*
        public static bool EnableThemingFromIUPDll()
        {

            IntPtr hActCtx;
            ACTCTX actCtx=new ACTCTX();

            const int ACTCTX_FLAG_HMODULE_VALID = 128;
            const int ACTCTX_FLAG_RESOURCE_NAME_VALID = 8;


            IntPtr hInst=IUPNative.IupGetGlobal("DLL_HINSTANCE");

            actCtx.cbSize = Marshal.SizeOf(actCtx);
            actCtx.dwFlags = ACTCTX_FLAG_HMODULE_VALID | ACTCTX_FLAG_RESOURCE_NAME_VALID;
            actCtx.lpApplicationName = null;
            actCtx.lpAssemblyDirectory = null;
            actCtx.lpResourceName = (IntPtr)9;
            actCtx.lpSource = null;
            actCtx.wLangId = 0;
            actCtx.wProcessorArchitecture = 0;
            actCtx.hModule = hInst;


            int err = Marshal.GetLastWin32Error();


            hActCtx = CreateActCtxA(ref actCtx);


            err=Marshal.GetLastWin32Error();

            //if (hActCtx != INVALID_HANDLE_VALUE)
            {
                IntPtr cookie = IntPtr.Zero;
                bool res=ActivateActCtx(hActCtx, cookie);

                

                //DeactivateActCtx(0, cookie);
                //ReleaseActCtx(hActCtx);
            }


            return true;
        }*/


        public static void AddNativeDllPath()
        {
            if (IsRunningOnWindows)
            {
                string appPath = Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]),(IntPtr.Size == 4)? "tec32":"tec64");
                Environment.SetEnvironmentVariable("PATH", appPath+";"+Environment.GetEnvironmentVariable("PATH"));
            }

        }

        public static bool IsRunningOnWindows
        {
            get
            {
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            }
        }

    }

}
