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
        public static IupError Open()
        {
            WindowsSpecific.AddNativeDllPath();

            int argc = 0;
            string argv = string.Empty;
            IupError res=IupOpen(ref argc, ref argv);

            IupNative.IupSetStrGlobal("UTF8MODE", "YES");
            IupNative.IupSetStrGlobal("UTF8MODE_FILE", "YES");

            return res;
        }

        public static void Close()
        {
            IupClose();
        }


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






        public static IntPtr Dialog(IntPtr child) => IupDialog(child);
        public static IntPtr Button(string title, string action) => IupButton(title, action);

        /*
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

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupMenu", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupMenu(IntPtr child);


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

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTabs", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupTabs(IntPtr child);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupTabsv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupTabsv(IntPtr children);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatTabs", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatTabs(IntPtr first);

        [SuppressUnmanagedCodeSecurity, DllImport(module, EntryPoint = "IupFlatTabsv", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IupFlatTabsv(IntPtr children);

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
        */


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
