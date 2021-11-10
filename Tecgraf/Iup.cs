using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using static Tecgraf.IupNative;

namespace Tecgraf
{
    public static class Iup
    {
       

        

        #region MAIN_API


        public static IupError Open()
        {
            WindowsSpecific.AddNativeDllPath();

            int argc = 0;
            string argv = string.Empty;
            IupError res = IupOpen(ref argc, ref argv);

            IupNative.IupSetStrGlobal("UTF8MODE", "YES");
            IupNative.IupSetStrGlobal("UTF8MODE_FILE", "YES");

            return res;
        }

        public static void Close()
        {
            IupClose();
        }

        public static bool IsOpened() => IupIsOpened();
        public static void MainLoop() => IupMainLoop();
        public static CBRes LoopStep() => IupLoopStep();
        public static CBRes LoopStepWait() => IupLoopStepWait();
        public static int MainLoopLevel() => IupMainLoopLevel();
        public static void Flush() => IupFlush();
        public static void ExitLoop() => IupExitLoop();
        public static void PostMessage(IntPtr ih, string s, int i, double d, IntPtr p) => IupPostMessage(ih, s, i, d, p);
        public static IupError RecordInput(string filename, RecordInputMode mode) => IupRecordInput(filename, mode);
        public static IupError PlayInput(string filename) => IupPlayInput(filename);
        public static void Update(IntPtr ih) => IupUpdate(ih);
        public static void UpdateChildren(IntPtr ih) => IupUpdateChildren(ih);
        public static void Redraw(IntPtr ih, bool children) => IupRedraw(ih, children);
        public static void Refresh(IntPtr ih) => IupRefresh(ih);
        public static void RefreshChildren(IntPtr ih) => IupRefreshChildren(ih);
        public static bool Execute(string filename, string parameters) => IupExecute(filename, parameters)>0;
        public static bool ExecuteWait(string filename, string parameters) => IupExecuteWait(filename, parameters) > 0;
        public static bool Help(string url) => IupHelp(url)>0;
        public static void Log(string type, string format) => IupLog(type, format);
        public static string Load(string filename) => IupLoad(filename);
        public static string LoadBuffer(string buffer) => IupLoadBuffer(buffer);
        public static string Version() => IupVersion();
        public static string VersionDate() => IupVersionDate();
        public static int VersionNumber() => IupVersionNumber();
        public static void VersionShow() => IupVersionShow();
        public static void SetLanguage(string lng) => IupSetLanguage(lng);
        public static void GetLanguage() => IupGetLanguage();
        public static void StoreLanguageString(string name, string str) => IupStoreLanguageString(name, str);
        public static string GetLanguageString(string name) => IupGetLanguageString(name);
        public static void SetLanguagePack(IntPtr ih) => IupSetLanguagePack(ih);
        public static void Destroy(IntPtr ih) => IupDestroy(ih);
        public static void Detach(IntPtr child) => IupDetach(child);
        public static IntPtr Append(IntPtr ih, IntPtr child) => IupAppend(ih, child);
        public static IntPtr Insert(IntPtr ih, IntPtr ref_child, IntPtr child) => IupInsert(ih, ref_child, child);
        public static IntPtr GetChild(IntPtr ih, int pos) => IupGetChild(ih, pos);
        public static int GetChildPos(IntPtr ih,IntPtr child)=>IupGetChildPos(ih, child);
        public static int GetChildCount(IntPtr ih) => IupGetChildCount(ih);
        public static IntPtr GetNextChild(IntPtr ih, IntPtr child)=>IupGetNextChild(ih,child);
        public static IntPtr GetBrother(IntPtr ih) => IupGetBrother(ih);
        public static IntPtr GetParent(IntPtr ih) => IupGetParent(ih);
        public static IntPtr GetDialog(IntPtr ih) => IupGetDialog(ih);
        public static IntPtr GetDialogChild(IntPtr ih, string name) => IupGetDialogChild(ih, name);
        public static IupError Reparent(IntPtr ih, IntPtr new_parent, IntPtr ref_child) => IupReparent(ih, new_parent, ref_child);
        public static IupError Popup(IntPtr ih, int x, int y) => IupPopup(ih, x, y);
        public static IupError Show(IntPtr ih) => IupShow(ih);
        public static IupError ShowXY(IntPtr ih) => IupShow(ih);
        public static IupError Hide(IntPtr ih) => IupHide(ih);
        public static IupError Map(IntPtr ih) => IupMap(ih);
        public static void Unmap(IntPtr ih) => IupUnmap(ih);
        public static void ResetAttribute(IntPtr ih, string name) => IupResetAttribute(ih, name);
        
        public static string[] GetAllAttributes(IntPtr ih)
        {
            IntPtr dummy = IntPtr.Zero;
            int n = IupGetAllAttributes(ih, ref dummy, 0);

            IntPtr[] ptrstr = new IntPtr[n];
            IupGetAllAttributes(ih, ref ptrstr[0], n);



        }

        /*

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


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetInt", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetInt(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetFloat", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetFloat(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, float value);

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
        public static extern void IupGetRGBA(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, out byte r, out byte g, out byte b, out byte a);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetAttributeId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrAttributeId", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int id, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

       
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
        public static extern void IupSetAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrAttributeId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrfId2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrfId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

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
        public static extern void IupGetRGBId2(IntPtr ih, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int lin, int col, out byte r, out byte g, out byte b);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, IntPtr value);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupSetStrGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IupSetStrGlobal([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string value);


        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupGetGlobal", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IupGetGlobalPtr([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
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

        */
        #endregion MAIN_API



        #region ELEMENT_CREATION

        public static IntPtr Fill() => IupFill();
        public static IntPtr Space() => IupSpace();
        public static IntPtr Radio(IntPtr child) => IupRadio(child);
        public static IntPtr Vbox(IntPtr child) => IupVbox(child);
        public static IntPtr ZBox(IntPtr child) => IupZbox(child);
        public static IntPtr HBox(IntPtr child) => IupZbox(child);
        public static IntPtr Normalizer(IntPtr ih_first) => IupNormalizer(ih_first);
        public static IntPtr CBox(IntPtr[] children) => IupCboxv(ref children[0]);
        public static IntPtr SBox(IntPtr child) => IupSbox(child);
        public static IntPtr Split(IntPtr child1,IntPtr child2) => IupSplit(child1,child2);
        public static IntPtr ScrollBox(IntPtr child) => IupScrollBox(child);
        public static IntPtr FlatScrollBox(IntPtr child) => IupFlatScrollBox(child);
        public static IntPtr GridBox(IntPtr[] children) => IupGridBoxv(ref children[0]);
        public static IntPtr MultiBox(IntPtr[] children) => IupMultiBoxv(ref children[0]);
        public static IntPtr Expander(IntPtr child) => IupExpander(child);
        public static IntPtr DetachBox(IntPtr child) => IupDetachBox(child);
        public static IntPtr BackgroundBox(IntPtr child) => IupDetachBox(child);
        public static IntPtr Frame(IntPtr child) => IupFrame(child);
        public static IntPtr FlatFrame(IntPtr child) => IupFlatFrame(child);
        public static IntPtr Image(int width, int height, IntPtr pixels) => IupImage(width,height,pixels);
        public static IntPtr ImageRGB(int width, int height, IntPtr pixels) => IupImage(width,height,pixels);
        public static IntPtr ImageRGBA(int width, int height, IntPtr pixels) => IupImage(width, height, pixels);
        public static IntPtr Item(string title, string action) => IupItem(title, action);
        public static IntPtr Submenu(string title, IntPtr child) => IupSubmenu(title, child);
        public static IntPtr Menu(IntPtr[] children) => IupMenuv(ref children[0]);
        public static IntPtr Button(string title, string action) => IupButton(title, action);
        public static IntPtr FlatButton(string title) => IupFlatButton(title);
        public static IntPtr FlatToggle(string title) => IupFlatToggle(title);
        public static IntPtr FlatLabel(string title) => IupFlatLabel(title);
        public static IntPtr DropButton(IntPtr dropchild) => IupDropButton(dropchild);
        public static IntPtr FlatSeparator() => IupFlatSeparator();
        public static IntPtr Canvas(string action) => IupCanvas(action);
        public static IntPtr Dialog(IntPtr child) => IupDialog(child);
        public static IntPtr User() => IupUser();
        public static IntPtr Thread() => IupThread();
        public static IntPtr Label(string title) => IupLabel(title);
        public static IntPtr ListBox(string action) => IupList(action);
        public static IntPtr FlatListBox() => IupFlatList();
        public static IntPtr TextBox(string action) => IupText(action);
        public static IntPtr Toggle(string title,string action) => IupToggle(title,action);
        public static IntPtr Timer() => IupTimer();
        public static IntPtr Clipboard() => IupClipboard();
        public static IntPtr ProgressBar() => IupProgressBar();
        public static IntPtr Valuator(string type) => IupVal(type);
        public static IntPtr FlatValuator(string type) => IupFlatVal(type);
        public static IntPtr FlatTree() => IupFlatTree();
        public static IntPtr Tabs(IntPtr[] children) => IupTabsv(ref children[0]);
        public static IntPtr FlatTabs(IntPtr[] children) => IupFlatTabsv(ref children[0]);
        public static IntPtr Tree(IntPtr[] children) => IupTree();
        public static IntPtr Link(string url, string title) => IupLink(url, title);
        public static IntPtr AnimatedLabel(IntPtr animation) => IupAnimatedLabel(animation);
        public static IntPtr DatePick() => IupDatePick();
        public static IntPtr Calendar() => IupCalendar();
        public static IntPtr Colorbar() => IupColorbar();
        public static IntPtr Gauge() => IupGauge();
        public static IntPtr Dial(string type) => IupDial(type);
        public static IntPtr ColorBrowser() => IupColorBrowser();

        #endregion ELEMENT_CREATION

        #region PREDEFINED_DIALOGS




        public static FileStatus GetFile(ref string fileName)
        {
            StringBuilder sb = new StringBuilder(4096);
            if (!string.IsNullOrWhiteSpace(fileName))
                sb.Append(fileName);

            FileStatus res = IupGetFile(sb);
            if (res != FileStatus.Cancel)
                fileName = sb.ToString();
            return res;
        }

        public static void Message(string title, string msg)
        {
            IupMessage(title, msg);
        }

        public static void Message(string msg)
        {
            IupMessage("", msg);
        }


        public static void MessageError(Dialog parent, string msg)
        {
            IupMessageError(parent != null ? parent.Handle : IntPtr.Zero, msg);
        }
        public static void MessageError(string msg)
        {
            IupMessageError(IntPtr.Zero, msg);
        }

        public static int MessageAlarm(Dialog parent, string title, string message, MessageButtons buttons)
        {

            string att = IupFormat.EnumToAtt(buttons,
                "OK", MessageButtons.Ok,
                "OKCANCEL", MessageButtons.OkCancel,
                "RETRYCANCEL", MessageButtons.RetryCancel,
                "YESNO", MessageButtons.YesNo,
                "YESNOCANCEL", MessageButtons.YesNoCancel);

            return IupMessageAlarm(parent != null ? parent.Handle : IntPtr.Zero, title, message, att);
        }

        public static int MessageAlarm(string title, string message, MessageButtons buttons)
        {
            return MessageAlarm(null, title, message, buttons);
        }

        public static bool YesNo(string title, string message)
        {
            return MessageAlarm(title, message, MessageButtons.YesNo) == 1;
        }

        public static bool YesNo(string message)
        {
            return MessageAlarm("", message, MessageButtons.YesNo) == 1;
        }

        public static int Alarm(string title, string msg, string btn1, string btn2, string btn3)
        {
            return IupAlarm(title, msg, btn1, btn2, btn3);
        }


        public static bool ListDialog(string title, int max_col, int max_lin, params ListDialogEntry[] list)
        {

            // multiselect version

            IntPtr[] strlst = new IntPtr[list.Length];
            int[] marklst = new int[list.Length];

            

            for (int i = 0; i < strlst.Length; i++)
            {
                strlst[i] = Marshal.StringToCoTaskMemUTF8(list[i].Text);
                marklst[i] = list[i].Selected ? 1 : 0;
            }

            bool res = IupListDialog(2, title, strlst.Length, ref strlst[0], 1, max_col, max_lin, marklst) < 0;
                

            // writeback result and free strings
            for (int i = 0; i < strlst.Length; i++)
            {
                list[i].Selected = marklst[i] != 0;
                Marshal.FreeCoTaskMem(strlst[i]);
            }
            return res;


            #endregion
        }

        public static int ListDialog(string title, int op,int max_col, int max_lin, params string[] list)
        {
            IntPtr[] strlst = new IntPtr[list.Length];

            for (int i = 0; i < strlst.Length; i++)
                strlst[i] = Marshal.StringToCoTaskMemUTF8(list[i]);

            int res=IupListDialog(1, title, strlst.Length, ref strlst[0], op+1, max_col, max_lin, null);

            for (int i = 0; i < strlst.Length; i++)
                Marshal.FreeCoTaskMem(strlst[i]);

            return res;
        }

        public static bool GetText(string title,ref string text,int maxsize)
        {
            int buildersize = maxsize + 1;
            if (maxsize == 0)
                buildersize = text.Length+1;

            StringBuilder sb = new StringBuilder(Math.Max(buildersize,4));
            if (text != null)
                sb.Append(text);
            bool res=IupGetText(title, sb, maxsize);
            if (res)
            {
                text = sb.ToString();
                return true;
            }
            return false;
        }

        public static bool GetColor(int x, int y, ref Color color)
        {

            byte r = color.R;
            byte g = color.G;
            byte b = color.B;

            if (IupGetColor(x, y, ref r,ref g,ref b))
            {
                color = Color.FromArgb(255, r, g, b);
                return true;
            }
            return false;
        }


    }

    public class ListDialogEntry
    {
        public readonly string Text;
        public bool Selected;

        public ListDialogEntry(string txt, bool selected)
        {
            this.Text = txt;
            this.Selected = selected;
        }

        public override string ToString()
        {
            return Text + " : " + Selected.ToString();
        }
    }
}
