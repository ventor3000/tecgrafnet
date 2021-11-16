using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    public class FileDialog:Element
    {
        public FileDialog():base(Iup.FileDlg())
        {

        }

        public FileDialogType DialogType
        {
            get => IupFormat.AttToEnum<FileDialogType>("DIALOGTYPE", "OPEN", FileDialogType.Open, "SAVE", FileDialogType.Save, "DIR", FileDialogType.Directory);
            set => Iup.SetAttribute(Handle,"DIALOGTYPE",IupFormat.EnumToAtt<FileDialogType>(value, "OPEN", FileDialogType.Open, "SAVE", FileDialogType.Save, "DIR", FileDialogType.Directory));
        }


        public IupError Popup(int x, int y) => Iup.Popup(Handle, x, y);
        public IupError Popup(DialogPos xpos, DialogPos ypos) => Iup.Popup(Handle, (int)xpos, (int)ypos);
        public IupError Popup(int xpos, DialogPos ypos) => Iup.Popup(Handle, xpos, (int)ypos);
        public IupError Popup(DialogPos xpos, int ypos) => Iup.Popup(Handle, (int)xpos, ypos);
   

        #region CALLBACKS
        public IcallbackFileCB CBFile
        {
            get
            {
                IntPtr cb = Iup.GetCallback(Handle, "FILE_CB");
                if (cb == IntPtr.Zero) return null;
                return Marshal.GetDelegateForFunctionPointer<IcallbackFileCB>(cb);
            }

            set
            {
                Iup.SetCallback(Handle, "FILE_CB", value);
            }
        }

        #endregion
    }



    public enum FileDialogType
    {
        Open=0,
        Save=1,
        Directory=2
    }
}
