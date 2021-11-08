using System;
using System.Collections.Generic;
using System.Text;

using static Tecgraf.IupNative;

namespace Tecgraf
{
    public class Dialog:Control
    {
        public Dialog(string caption, Element child) : base(IupDialog(child.Handle))
        {
            if (caption != null)
                IupSetStrAttribute(Handle, "TITLE", caption);
        }


        public IupError Show()
        {
            return IupShow(Handle);
        }




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

        private int OnMoveCB(IntPtr sender, int x, int y)
        {

            moveCBHandler?.Invoke(sender, new MoveCBEventArgs(x, y));
            return 0;
        }

        #endregion BUTTON_CB

    }
}
