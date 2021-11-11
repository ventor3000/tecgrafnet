using System;
using System.Collections.Generic;
using System.Text;


namespace Tecgraf
{
    public class Dialog:Control
    {
        public Dialog(string caption, Element child) : base(Iup.Dialog(child.Handle))
        {
            if (caption != null)
                Iup.SetAttribute(Handle, "TITLE", caption);
        }


        public IupError Show()
        {
            return Iup.Show(Handle);
        }

        public string Title
        {
            get => Iup.GetAttribute(Handle, "TITLE");
            set => Iup.SetAttribute(Handle, "TITLE", value);
        }


        
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
