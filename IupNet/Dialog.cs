using System;
using System.Collections.Generic;
using System.Text;


namespace Tecgraf
{
    public class Dialog:Container
    {
        public Dialog(string caption, Element child) : base(Iup.Dialog(SafeHandle(child)))
        {
            if (caption != null)
                Iup.SetAttribute(Handle, "TITLE", caption);
        }


       

        public string Title
        {
            get => Iup.GetAttribute(Handle, "TITLE");
            set => Iup.SetAttribute(Handle, "TITLE", value);
        }



        public IupError Popup(int x, int y) => Iup.Popup(Handle, x, y);
        public IupError Popup(DialogPos xpos, DialogPos ypos) => Iup.Popup(Handle, (int)xpos, (int)ypos);
        public IupError Popup(int xpos, DialogPos ypos) => Iup.Popup(Handle, xpos, (int)ypos);
        public IupError Popup(DialogPos xpos, int ypos) => Iup.Popup(Handle, (int) xpos, ypos);
        public IupError ShowXY(int x, int y) => Iup.ShowXY(Handle, x, y);
        public IupError ShowXY(DialogPos xpos, DialogPos ypos) => Iup.ShowXY(Handle, (int)xpos, (int)ypos);
        public IupError ShowXY(int xpos, DialogPos ypos) => Iup.ShowXY(Handle, xpos, (int)ypos);
        public IupError ShowXY(DialogPos xpos, int ypos) => Iup.ShowXY(Handle, (int)xpos, ypos);

        /*

        #region MOVE_CB

        EventHandler<MoveCBEventArgs> moveCBHandler;

        public event EventHandler<MoveCBEventArgs> MoveCB
        {
            add
            {
                moveCBHandler += value;
                IupSetCallback(Handle, "MOVE_CB", OnMoveCB);

            }
            remove
            {
                moveCBHandler -= value;
                if (moveCBHandler == null) IupSetCallback(Handle, "MOVE_CB", (Icallback)null);

            }
        }

        private CBRes OnMoveCB(IntPtr sender, int x, int y)
        {

            moveCBHandler?.Invoke(sender, new MoveCBEventArgs(x, y));
            return 0;
        }

        #endregion BUTTON_CB*/

    }
}
