using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using static Tecgraf.IupNative;

namespace Tecgraf
{

    #region CALLBACKS
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate CBRes Icallback(IntPtr sender);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate CBRes IcallbackIIIIS(IntPtr sender, int button, int pressed, int x, int y, string status);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate CBRes IcallbackII(IntPtr sender, int x, int y);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate CBRes IcallbackButtonCB(IntPtr sender, MouseButton button, [MarshalAs(UnmanagedType.Bool)] bool pressed, int x, int y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ModifierStatusMarshaller))] ModifierStatus status);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate CBRes IcallbackMotionCB(IntPtr sender, int x, int y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ModifierStatusMarshaller))] ModifierStatus status);

    #endregion

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
        public static string GetLanguage() => IupGetLanguage();
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
            if(n>0)
                IupGetAllAttributes(ih, ref ptrstr[0], n);

            string[] attrs = new string[n];
            for (int i = 0; i < n; i++)
                attrs[i] = Marshal.PtrToStringUTF8(ptrstr[i]);

            return attrs;
        }

        public static void CopyAttributes(IntPtr src_ih, IntPtr dst_ih) => IupCopyAttributes(src_ih, dst_ih);
        public static void SetAtt(string handle_name, IntPtr ih, string name) => IupSetAtt(handle_name, ih, name);
        public static void SetAttributes(IntPtr ih, string str) => IupSetAttributes(ih, str);
        public static string GetAttributes(IntPtr ih) => IupGetAttributes(ih);
        public static void SetAttribute(IntPtr ih, string name, IntPtr value) => IupSetAttribute(ih, name, value);
        public static void SetAttribute(IntPtr ih, string name, string value) => IupSetStrAttribute(ih, name, value);
        public static void SetInt(IntPtr ih, string name, int value) => IupSetInt(ih, name, value);
        public static void SetFloat(IntPtr ih, string name, float value) => IupSetFloat(ih, name, value);
        public static void SetDouble(IntPtr ih, string name, double value) => IupSetDouble(ih, name, value);
        public static void SetRGB(IntPtr ih, string name, byte r,byte g,byte b) => IupSetRGB(ih, name,r,g,b);
        public static void SetRGB(IntPtr ih, string name, Color color) => IupSetRGB(ih, name, color.R, color.G, color.B);
        public static void SetRGB(IntPtr ih, string name, byte r, byte g, byte b,byte a) => IupSetRGBA(ih, name, r, g, b,a);
        public static void SetRGBA(IntPtr ih, string name, Color color) => IupSetRGBA(ih, name, color.R, color.G, color.B,color.A);
        public static string GetAttribute(IntPtr ih, string name) => IupGetAttribute(ih, name);
        public static int GetInt(IntPtr ih, string name) => IupGetInt(ih, name);
        public static int GetInt2(IntPtr ih, string name) => IupGetInt(ih, name);
        public static int GetIntInt(IntPtr ih, string name,out int i1, out int i2) => IupGetIntInt(ih, name, out i1, out i2);
        public static float GetFloat(IntPtr ih, string name) => IupGetFloat(ih, name);
        public static double GetDouble(IntPtr ih, string name) => IupGetDouble(ih, name);
        public static void GetRGB(IntPtr ih, string name, out byte r, out byte g, out byte b) => IupGetRGB(ih, name, out r, out g, out b);
        public static Color GetRGB(IntPtr ih, string name) { IupGetRGB(ih, name, out byte r, out byte g, out byte b); return Color.FromArgb(255, r, g, b); }
        public static void GetRGBA(IntPtr ih, string name, out byte r, out byte g, out byte b,out byte a) => IupGetRGBA(ih, name, out r, out g, out b,out a);
        public static Color GetRGBA(IntPtr ih, string name) { IupGetRGBA(ih, name, out byte r, out byte g, out byte b,out byte a); return Color.FromArgb(a, r, g, b); }
        public static void SetAttributeId(IntPtr ih, string name, int id, IntPtr value) => IupSetAttributeId(ih, name, id, value);
        public static void SetAttributeId(IntPtr ih, string name, int id, string value) => IupSetStrAttributeId(ih, name, id, value);
        public static void SetIntId(IntPtr ih, string name, int id, int value) => IupSetIntId(ih, name, id, value);
        public static void SetFloatId(IntPtr ih, string name, int id, float value) => IupSetFloatId(ih, name, id, value);
        public static void SetDoubleId(IntPtr ih, string name, int id, double value) => IupSetDoubleId(ih, name, id, value);
        public static void SetRGBId(IntPtr ih, string name, int id, byte r, byte g, byte b) => IupSetRGBId(ih, name, id, r, g, b);
        public static void SetRGBId(IntPtr ih, string name, int id, Color color) => IupSetRGBId(ih, name, id, color.R,color.G,color.B);
        public static string GetAttributeId(IntPtr ih, string name, int id) => IupGetAttributeId(ih, name, id);
        public static int GetIntId(IntPtr ih, string name, int id) => IupGetIntId(ih, name, id);
        public static float GetFloatId(IntPtr ih, string name, int id) => IupGetFloatId(ih, name, id);
        public static double GetDoubleId(IntPtr ih, string name, int id) => IupGetDoubleId(ih, name, id);
        public static void GetRGBId(IntPtr ih, string name, int id,out byte r,out byte g,out byte b) => IupGetRGBId(ih, name, id,out r,out g,out b);
        public static Color GetRGBId(IntPtr ih, string name, int id) { IupGetRGBId(ih, name, id, out byte r, out byte g, out byte b); return Color.FromArgb(255, r, g, b); }
        public static void SetAttributeId2(IntPtr ih, string name, int lin, int col, string value) => IupSetStrAttributeId2(ih, name, lin, col, value);
        public static void SetAttributeId2(IntPtr ih, string name, int lin, int col, IntPtr value) => IupSetAttributeId2(ih, name, lin, col, value);
        public static void SetIntId2(IntPtr ih, string name, int lin, int col, int value) => IupSetIntId2(ih, name, lin, col, value);
        public static void SetFloatId2(IntPtr ih, string name, int lin, int col, float value) => IupSetFloatId2(ih, name, lin, col, value);
        public static void SetDoubleId2(IntPtr ih, string name, int lin, int col, double value) => IupSetDoubleId2(ih, name, lin, col, value);
        public static void SetRGBId2(IntPtr ih, string name, int lin, int col, byte r, byte g, byte b) => IupSetRGBId2(ih, name, lin, col, r, g, b);
        public static void SetRGBId2(IntPtr ih, string name, int lin, int col, Color color) => IupSetRGBId2(ih, name, lin, col, color.R,color.G,color.B);
        public static string GetAttributeId2(IntPtr ih, string name, int lin, int col) => IupGetAttributeId2(ih, name, lin, col);
        public static int GetIntId2(IntPtr ih, string name, int lin, int col) => IupGetIntId2(ih, name, lin, col);
        public static float GetFloatId2(IntPtr ih, string name, int lin, int col) => IupGetFloatId2(ih, name, lin, col);
        public static double GetDoubleId2(IntPtr ih, string name, int lin, int col) => IupGetDoubleId2(ih, name, lin, col);

        public static void GetRGBId2(IntPtr ih, string name, int lin, int col, out byte r, out byte g, out byte b) => IupGetRGBId2(ih, name, lin, col, out r, out g, out b);
        public static Color GetRGBId2(IntPtr ih, string name, int lin, int col) { IupGetRGBId2(ih, name, lin, col, out byte r, out byte g, out byte b); return Color.FromArgb(255, r, g, b); }

        public static void SetGlobal(string name, IntPtr value) => IupSetGlobal(name, value);
        public static void SetGlobal(string name, string value) => IupSetStrGlobal(name, value);
        public static string GetGlobal(string name) => IupGetGlobal(name);
        public static void SetFocus(IntPtr ih) => IupSetFocus(ih);
        public static IntPtr GetFocus() => IupGetFocus();
        public static IntPtr PreviousField(IntPtr ih) => IupPreviousField(ih);
        public static IntPtr NextField(IntPtr ih) => IupNextField(ih);
        public static IntPtr GetCallback(IntPtr ih, string name) => IupGetCallback(ih, name);
        public static IntPtr SetCallback(IntPtr ih, string name,Delegate func) => IupSetCallback(ih, name,func);
        public static IntPtr GetHandle(string name) => IupGetHandle(name);
        public static IntPtr SetHandle(string name,IntPtr ih) => IupSetHandle(name,ih);
        public static string[] GetAllNames()
        {
            IntPtr dummy = IntPtr.Zero;
            int n = IupGetAllNames(ref dummy, 0);
            IntPtr[] namarr = new IntPtr[n];
            if (n > 0)
                IupGetAllNames(ref namarr[0], n);

            string[] res = new string[n];
            for (int i = 0; i < n; i++)
                res[i] = Marshal.PtrToStringUTF8(namarr[i]);
            return res;
        }
        public static string[] GetAllDialogs()
        {
            IntPtr dummy = IntPtr.Zero;
            int n = IupGetAllDialogs(ref dummy, 0);
            IntPtr[] namarr = new IntPtr[n];
            if (n > 0)
                IupGetAllDialogs(ref namarr[0], n);

            string[] res = new string[n];
            for (int i = 0; i < n; i++)
                res[i] = Marshal.PtrToStringUTF8(namarr[i]);
            return res;
        }
        public static string GetName(IntPtr ih) => IupGetName(ih);
        public static void SetAttributeHandle(IntPtr ih, string name, IntPtr ih_named) => IupSetAttributeHandle(ih, name, ih_named);
        public static IntPtr GetAttributeHandle(IntPtr ih, string name) => IupGetAttributeHandle(ih, name);
        public static void SetAttributeHandleId(IntPtr ih, string name, int id,IntPtr ih_named) => IupSetAttributeHandleId(ih, name, id,ih_named);
        public static IntPtr GetAttributeHandleId(IntPtr ih, string name,int id) => IupGetAttributeHandleId (ih, name,id);
        public static void SetAttributeHandleId2(IntPtr ih, string name, int lin,int col, IntPtr ih_named) => IupSetAttributeHandleId2(ih, name, lin,col, ih_named);
        public static IntPtr GetAttributeHandleId2(IntPtr ih, string name, int lin,int col) => IupGetAttributeHandleId2(ih, name, lin,col);
        public static string GetClassName(IntPtr ih) => IupGetClassName(ih);
        public static string GetClassType(IntPtr ih) => IupGetClassType(ih);
        public static string[] GetAllClasses()
        {
            IntPtr dummy = IntPtr.Zero;
            int n = IupGetAllClasses(ref dummy, 0);
            IntPtr[] namarr = new IntPtr[n];
            if (n > 0)
                IupGetAllClasses(ref namarr[0], n);

            string[] res = new string[n];
            for (int i = 0; i < n; i++)
                res[i] = Marshal.PtrToStringUTF8(namarr[i]);
            return res;
        }

        public static string[] GetClassAttributes(string classname)
        {
            IntPtr dummy = IntPtr.Zero;
            int n = IupGetClassAttributes(classname,ref dummy, 0);
            IntPtr[] namarr = new IntPtr[n];
            if (n > 0)
            {
                n=IupGetClassAttributes(classname, ref namarr[0], n);
                Array.Resize(ref namarr, n);
            }
            
            string[] res = new string[n];
            for (int i = 0; i < n; i++)
                res[i] = Marshal.PtrToStringUTF8(namarr[i]);
            return res;
        }

        public static string[] GetClassCallbacks(string classname)
        {
            IntPtr dummy = IntPtr.Zero;
            int n = IupGetClassCallbacks(classname, ref dummy, 0);
            IntPtr[] namarr = new IntPtr[n];
            if (n > 0)
            {
                n = IupGetClassCallbacks(classname, ref namarr[0], n);
                Array.Resize(ref namarr, n);
            }

            string[] res = new string[n];
            for (int i = 0; i < n; i++)
                res[i] = Marshal.PtrToStringUTF8(namarr[i]);
            return res;
        }

        public static void SaveClassAttributes(IntPtr ih) => IupSaveClassAttributes(ih);
        public static void CopyClassAttributes(IntPtr src_ih,IntPtr dst_ih) => IupCopyClassAttributes(src_ih,dst_ih);
        public static void SetClassDefaultAttribute(string classname,string name,string value) => IupSetClassDefaultAttribute(classname,name,value);
        public static bool ClassMatch(IntPtr ih, string classname) => IupClassMatch(ih, classname);
        public static IntPtr Create(string classname) => IupCreate(classname);
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
