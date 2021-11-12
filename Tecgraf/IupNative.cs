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


        #region MAIN_API

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
        public static extern CBRes IupLoopStep();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLoopStepWait", CallingConvention = CallingConvention.Cdecl)]
        public static extern CBRes IupLoopStepWait();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMainLoopLevel", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupMainLoopLevel();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlush", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupFlush();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupExitLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupExitLoop();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupPostMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupPostMessage(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string s, int i, double d, IntPtr p);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupRecordInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupRecordInput([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, RecordInputMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupPlayInput", CallingConvention = CallingConvention.Cdecl)]
        public static extern IupError IupPlayInput([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupUpdate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupUpdate(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupUpdateChildren", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupUpdateChildren(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupRedraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupRedraw(IntPtr ih, [MarshalAs(UnmanagedType.Bool)] bool children);

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
        public static string IupLoadBuffer(string buffer) => Marshal.PtrToStringUTF8(IupLoadBufferPtr(buffer));


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

        // HINT: varargs seems broken in newer visual studios...??
        //[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrf", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void IupSetStrf(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format,__arglist); //TODO: this does not work, why?


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetInt(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetFloat", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetFloat(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)]  string name, float value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetDouble", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetDouble(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, double value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetRGB", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetRGB(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, byte r, byte g, byte b);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetRGBA", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetRGBA(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, byte r, byte g, byte b, byte a);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttribute", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetAttributePtr(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        public static string IupGetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name) => Marshal.PtrToStringUTF8(IupGetAttributePtr(ih, name));





        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetInt(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetInt2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetInt2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetIntInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetIntInt(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, out int i1, out int i2);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetFloat", CallingConvention = CallingConvention.Cdecl)]
        public static extern float IupGetFloat(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetDouble", CallingConvention = CallingConvention.Cdecl)]
        public static extern double IupGetDouble(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetRGB", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupGetRGB(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, out byte r, out byte g, out byte b);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetRGBA", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupGetRGBA(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, out byte  r, out byte  g, out byte  b, out byte a);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttributeId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id,IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrAttributeId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        // HINT: varargs seems broken in newer visual studios...??
        //[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrfId", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void IupSetStrfId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, __arglist);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetIntId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetIntId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, int value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetFloatId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetFloatId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, float value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetDoubleId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetDoubleId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, double value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetRGBId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetRGBId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, byte r, byte g, byte b);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttributeId", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetAttributeIdPtr(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id);
        public static string IupGetAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id) => Marshal.PtrToStringUTF8(IupGetAttributeIdPtr(ih, name, id));

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetIntId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetIntId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetFloatId", CallingConvention = CallingConvention.Cdecl)]
        public static extern float IupGetFloatId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetDoubleId", CallingConvention = CallingConvention.Cdecl)]
        public static extern double IupGetDoubleId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetRGBId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupGetRGBId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, out byte r, out byte g, out byte b);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttributeId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrAttributeId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        /*
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrfId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrfId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, [MarshalAs(UnmanagedType.LPUTF8Str)] string format,__arglist);
        */

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetIntId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetIntId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, int value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetFloatId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetFloatId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, float value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetDoubleId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetDoubleId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, double value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetRGBId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetRGBId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, byte r, byte g, byte b);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttributeId2", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetAttributeId2Ptr(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col);
        public static string IupGetAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col) => Marshal.PtrToStringAnsi(IupGetAttributeId2Ptr(ih, name, lin, col));

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetIntId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetIntId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetFloatId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern float IupGetFloatId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetDoubleId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern double IupGetDoubleId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetRGBId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupGetRGBId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col,out byte r, out byte g, out byte b);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetGlobalPtr([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
        public static string IupGetGlobal(string name) => Marshal.PtrToStringUTF8(IupGetGlobalPtr(name));


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetFocus", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetFocus(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetFocus", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetFocus();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupPreviousField", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupPreviousField(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupNextField", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupNextField(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);




        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, Delegate func);

        /*

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, Icallback func);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IcallbackIIIIS func);
        
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IcallbackII func);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IcallbackButtonCB func);*/


        // HINT: varargs seems broken in newer visual studios...??
        //[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetCallbacks", CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr IupSetCallbacks(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, Icallback func,__arglist);


        /* Thoose should not be used by new applications according to iup docs so we skip them
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetFunction([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetFunction([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr func);
        */

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetHandle([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSetHandle([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr ih);

        

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAllNames", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetAllNames(ref IntPtr names, int n);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAllDialogs", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetAllDialogs(ref IntPtr names, int n);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetNamePtr(IntPtr ih);
        public static string IupGetName(IntPtr ih) => Marshal.PtrToStringUTF8(IupGetNamePtr(ih));

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttributeHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttributeHandle(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr ih_named);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttributeHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetAttributeHandle(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttributeHandleId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttributeHandleId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, IntPtr ih_named);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttributeHandleId", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetAttributeHandleId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttributeHandleId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttributeHandleId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, IntPtr ih_named);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAttributeHandleId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGetAttributeHandleId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetClassName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetClassNamePtr(IntPtr ih);
        public static string IupGetClassName(IntPtr ih) => Marshal.PtrToStringUTF8(ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetClassType", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetClassTypePtr(IntPtr ih);
        public static string IupGetClassType(IntPtr ih) => Marshal.PtrToStringUTF8(ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetAllClasses", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetAllClasses(ref IntPtr names, int n);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetClassAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetClassAttributes([MarshalAs(UnmanagedType.LPUTF8Str)] string classname, ref IntPtr names, int n);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetClassCallbacks", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetClassCallbacks([MarshalAs(UnmanagedType.LPUTF8Str)] string classname, ref IntPtr names, int n);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSaveClassAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSaveClassAttributes(IntPtr ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCopyClassAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupCopyClassAttributes(IntPtr src_ih, IntPtr dst_ih);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetClassDefaultAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetClassDefaultAttribute([MarshalAs(UnmanagedType.LPUTF8Str)] string classname, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupClassMatch", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IupClassMatch(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string classname);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupCreate([MarshalAs(UnmanagedType.LPUTF8Str)] string classname);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCreatev", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupCreatev([MarshalAs(UnmanagedType.LPUTF8Str)] string classname, ref IntPtr pars);

        /* // HINT: varargs seems broken in newer visual studios...??
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCreatep", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupCreatep([MarshalAs(UnmanagedType.LPUTF8Str)] string classname, IntPtr first__arglist);
        */


        #endregion


        #region ELEMENT_CREATION
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFill", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFill();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSpace", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSpace();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupRadio", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupRadio(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVbox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupVbox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVboxv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupVboxv(IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupZbox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupZbox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupZboxv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupZboxv(IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupHbox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupHbox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupHboxv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupHboxv(IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupNormalizer", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupNormalizer(IntPtr ih_first);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupNormalizerv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupNormalizerv(IntPtr ih_list);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCbox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupCbox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCboxv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupCboxv(ref IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSbox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSbox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSplit", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSplit(IntPtr child1, IntPtr child2);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupScrollBox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupScrollBox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatScrollBox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatScrollBox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGridBox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGridBox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGridBoxv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGridBoxv(ref IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMultiBox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupMultiBox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMultiBoxv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupMultiBoxv(ref IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupExpander", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupExpander(IntPtr child);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDetachBox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupDetachBox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupBackgroundBox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupBackgroundBox(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFrame", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFrame(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatFrame", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatFrame(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupImage", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupImage(int width, int height, IntPtr pixels);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupImageRGB", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupImageRGB(int width, int height, IntPtr pixels);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupImageRGBA", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupImageRGBA(int width, int height, IntPtr pixels);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupItem", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupItem([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSubmenu", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSubmenu([MarshalAs(UnmanagedType.LPUTF8Str)] string title, IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSeparator", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSeparator();

        /*[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMenu", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupMenu(IntPtr child__arglist);
        */

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMenuv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupMenuv(ref IntPtr children);
        

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupButton", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupButton([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatButton", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatButton([MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatToggle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatToggle([MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDropButton", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupDropButton(IntPtr dropchild);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatLabel", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatLabel([MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatSeparator", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatSeparator();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCanvas", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupCanvas([MarshalAs(UnmanagedType.LPUTF8Str)] string action);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupDialog(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupUser", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupUser();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupThread", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupThread();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLabel", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupLabel([MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupList", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupList([MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatList", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatList();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupText", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupText([MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMultiLine", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupMultiLine([MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupToggle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupToggle([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string action);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTimer", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupTimer();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupClipboard", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupClipboard();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupProgressBar", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupProgressBar();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupVal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupVal([MarshalAs(UnmanagedType.LPUTF8Str)] string type);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatVal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatVal([MarshalAs(UnmanagedType.LPUTF8Str)] string type);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatTree", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatTree();

        /*[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTabs", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupTabs(IntPtr child,__Arglist);*/

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTabsv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupTabsv(ref IntPtr children);

        /*[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatTabs", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatTabs(IntPtr first,__arglist);*/

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatTabsv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatTabsv(ref IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTree", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupTree();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLink", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupLink([MarshalAs(UnmanagedType.LPUTF8Str)] string url, [MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupAnimatedLabel", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupAnimatedLabel(IntPtr animation);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDatePick", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupDatePick();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupCalendar", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupCalendar();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupColorbar", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupColorbar();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGauge", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGauge();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupDial", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupDial([MarshalAs(UnmanagedType.LPUTF8Str)] string type);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupColorBrowser", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupColorBrowser();

        /* Skipped, IUP documentation tells to use the SPIN attribute of an IupText from now on (:
         * 
         * [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSpin", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSpin();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSpinbox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupSpinbox(IntPtr child);*/

        #endregion ELEMENT_CREATION


        #region UTILITIES
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupStringCompare", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupStringCompare([MarshalAs(UnmanagedType.LPUTF8Str)] string str1, [MarshalAs(UnmanagedType.LPUTF8Str)] string str2, [MarshalAs(UnmanagedType.Bool)] bool casesensitive, [MarshalAs(UnmanagedType.Bool)] bool lexicographic);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSaveImageAsText", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupSaveImageAsText(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupImageGetHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupImageGetHandle([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTextConvertLinColToPos", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupTextConvertLinColToPos(IntPtr ih, int lin, int col, out int pos);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTextConvertPosToLinCol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupTextConvertPosToLinCol(IntPtr ih, int pos, out int lin, out int col);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupConvertXYToPos", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupConvertXYToPos(IntPtr ih, int x, int y);


        /* OLD names, skipped in .NET wrapper so they are never used
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupStoreGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupStoreGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupStoreAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupStoreAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetfAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetfAttribute(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format,__arglist);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupStoreAttributeId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupStoreAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetfAttributeId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetfAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, [MarshalAs(UnmanagedType.LPUTF8Str)] string f,__arglist);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupStoreAttributeId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupStoreAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetfAttributeId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetfAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, [MarshalAs(UnmanagedType.LPUTF8Str)] string format,__arglist);
        */

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTreeSetUserId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupTreeSetUserId(IntPtr ih, int id, IntPtr userid);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTreeGetUserId", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupTreeGetUserId(IntPtr ih, int id);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTreeGetId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupTreeGetId(IntPtr ih, IntPtr userid);

        /* deprecated, use IupSetAttributeHandleId
        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTreeSetAttributeHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupTreeSetAttributeHandle(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, IntPtr ih_named);
        */

        #endregion UTILITIES


        #region PREDEFINED_DIALOGS

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFileDlg", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFileDlg();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMessageDlg", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupMessageDlg();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupColorDlg", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupColorDlg();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFontDlg", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFontDlg();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupProgressDlg", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupProgressDlg();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern FileStatus IupGetFile([In][Out] StringBuilder sb);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupMessage([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

        /*[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMessagef", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupMessagef([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string format__arglist);*/

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMessageError", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupMessageError(IntPtr parent, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMessageAlarm", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupMessageAlarm(IntPtr parent, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, [MarshalAs(UnmanagedType.LPUTF8Str)] string buttons);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupAlarm", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupAlarm([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg, [MarshalAs(UnmanagedType.LPUTF8Str)] string b1, [MarshalAs(UnmanagedType.LPUTF8Str)] string b2, [MarshalAs(UnmanagedType.LPUTF8Str)] string b3);

        /*[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupScanf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupScanf([MarshalAs(UnmanagedType.LPUTF8Str)] string format,__arglist);*/

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupListDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupListDialog(int type, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, int size, ref IntPtr list, int op, int max_col, int max_lin,[In][Out] int[] marks);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetText", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IupGetText([MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)][In][Out]StringBuilder text, int maxsize);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetColor", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IupGetColor(int x, int y, ref byte r, ref byte g, ref byte b);

        /*[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetParam([MarshalAs(UnmanagedType.LPUTF8Str)] string title, IntPtr action, IntPtr user_data, [MarshalAs(UnmanagedType.LPUTF8Str)] string format,__arglist);
        */

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetParamv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IupGetParamv([MarshalAs(UnmanagedType.LPUTF8Str)] string title, IntPtr action, IntPtr user_data, [MarshalAs(UnmanagedType.LPUTF8Str)] string format, int param_count, int param_extra, ref IntPtr param_data);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupParam([MarshalAs(UnmanagedType.LPUTF8Str)] string format);

        /*[SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupParamBox", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupParamBox(IntPtr param,__arglist);*/

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupParamBoxv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupParamBoxv(IntPtr param_array);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupLayoutDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupLayoutDialog(IntPtr dialog);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupElementPropertiesDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupElementPropertiesDialog(IntPtr parent, IntPtr elem);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGlobalsDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupGlobalsDialog();

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupClassInfoDialog", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupClassInfoDialog(IntPtr parent);

        #endregion

    }



   
}
