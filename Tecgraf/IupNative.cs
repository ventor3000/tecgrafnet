using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Tecgraf
{
    public static class IupNative
    {

        const string module= "iup";

        #region CALLBACKS
        [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int Icallback(IntPtr sender);

        [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int IcallbackIIIIS(IntPtr sender, int button, int pressed, int x, int y, string status);

        [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int IcallbackII(IntPtr sender, int x, int y);

        #endregion


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupOpen", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupOpen(ref int argc, ref string argv);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupClose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupClose();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupIsOpened", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IupIsOpened();


        // TODO: support this, this does not reside in the same module/.dll
        //[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupImageLibOpen", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void IupImageLibOpen();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMainLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupMainLoop();


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLoopStep", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupLoopStep();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLoopStepWait", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupLoopStepWait();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMainLoopLevel", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupMainLoopLevel();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlush", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupFlush();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupExitLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupExitLoop();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupPostMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupPostMessage(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string s, int i, double d, IntPtr p);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupRecordInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupRecordInput([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int mode);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupPlayInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupPlayInput([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupUpdate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupUpdate(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupUpdateChildren", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupUpdateChildren(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupRedraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupRedraw(IntPtr ih, int children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupRefresh", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupRefresh(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupRefreshChildren", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupRefreshChildren(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupExecute", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupExecute([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string parameters);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupExecuteWait", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupExecuteWait([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string parameters);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupHelp", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupHelp([MarshalAs(UnmanagedType.LPUTF8Str)] string url);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLog", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupLog([MarshalAs(UnmanagedType.LPUTF8Str)] string type, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLoad", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupLoadPtr([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);
        public static string IupLoad(string filename) => Marshal.PtrToStringUTF8(IupLoadPtr(filename));


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLoadBuffer", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupLoadBufferPtr([MarshalAs(UnmanagedType.LPUTF8Str)] string buffer);
        public static string IupVersion(string buffer) => Marshal.PtrToStringUTF8(IupLoadBufferPtr(buffer));


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVersion", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupVersionPtr();
        public static string IupVersion()=> Marshal.PtrToStringUTF8(IupVersionPtr());
        


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVersionDate", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupVersionDatePtr();
        public static string IupVersionDate() => Marshal.PtrToStringUTF8(IupVersionDatePtr());


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVersionNumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupVersionNumber();


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVersionShow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupVersionShow();











        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupDialog(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupButton", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupButton([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupShow", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupShow(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetGlobal", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetGlobalPtr([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        public static string IupGetGlobal(string name) => Marshal.PtrToStringUTF8(IupGetGlobalPtr(name));


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, Icallback func);
        
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IcallbackIIIIS func);
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IcallbackII func);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupMessage([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVbox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupVbox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupAppend", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupAppend(IntPtr ih, IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttribute", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetAttributePtr(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        public static string IupGetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name) => Marshal.PtrToStringUTF8(IupGetAttributePtr(ih, name));

    }
}
