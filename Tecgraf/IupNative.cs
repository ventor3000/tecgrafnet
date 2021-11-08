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
        public static extern IupError IupOpen(ref int argc, ref string argv);

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


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetLanguage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetLanguage([MarshalAs(UnmanagedType.LPUTF8Str)] string lng);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetLanguage", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetLanguagePtr();
        public static string IupGetLanguage() => Marshal.PtrToStringUTF8(IupGetLanguagePtr());


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetLanguageString", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetLanguageString([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr str);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupStoreLanguageString", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupStoreLanguageString([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetLanguageString", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetLanguageStringPtr([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        public static string IupGetLanguageString(string name) => Marshal.PtrToStringUTF8(IupGetLanguageStringPtr(name));


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetLanguagePack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetLanguagePack(IntPtr ih);



        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDestroy", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupDestroy(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDetach", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupDetach(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupAppend", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupAppend(IntPtr ih, IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupInsert", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupInsert(IntPtr ih, IntPtr ref_child, IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetChild", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetChild(IntPtr ih, int pos);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetChildPos", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetChildPos(IntPtr ih, IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetChildCount", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetChildCount(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetNextChild", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetNextChild(IntPtr ih, IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetBrother", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetBrother(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetParent(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetDialog(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetDialogChild", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetDialogChild(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupReparent", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupReparent(IntPtr ih, IntPtr new_parent, IntPtr ref_child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupPopup", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupPopup(IntPtr ih, int x, int y);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupShow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupShow(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupShowXY", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupShowXY(IntPtr ih, int x, int y);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupHide", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupHide(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMap", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupMap(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupUnmap", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupUnmap(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupResetAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupResetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);



        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAllAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetAllAttributes(IntPtr ih, ref IntPtr names, int n);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCopyAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupCopyAttributes(IntPtr src_ih, IntPtr dst_ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAtt", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetAtt([MarshalAs(UnmanagedType.LPUTF8Str)] string handle_name, IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetAttributes(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttributes", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetAttributesPtr(IntPtr ih);
        public static string IupGetAttributes(IntPtr ih) => Marshal.PtrToStringUTF8(IupGetAttributesPtr(ih));


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrf", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrf(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format,__arglist); //TODO: this does not work, why?












        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupDialog(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupButton", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupButton([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetGlobal", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetGlobalPtr([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        public static string IupGetGlobal(string name) => Marshal.PtrToStringUTF8(IupGetGlobalPtr(name));


        

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

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttribute", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetAttributePtr(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        public static string IupGetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name) => Marshal.PtrToStringUTF8(IupGetAttributePtr(ih, name));

    }
}
