using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using static Tecgraf.IupNative;

namespace Tecgraf
{
    public class Button : Control
    {
        public Button(string caption) : base(IupButton(caption, string.Empty))
        {
        }



        #region BUTTON_CB
        /*
        EventHandler<ButtonCBEventArgs> buttonCBHandler;

        public event EventHandler<ButtonCBEventArgs> ButtonCB
        {
            add
            {
                buttonCBHandler += value;
                IupSetCallback(Handle, "BUTTON_CB", OnButtonCB);

            }
            remove
            {
                buttonCBHandler -= value;
                if (buttonCBHandler == null) IupSetCallback(Handle, "BUTTON_CB", (Icallback)null);

            }
        }

        private CBRes OnButtonCB(IntPtr sender, int btn, int pressed, int x, int y, string status)
        {

            buttonCBHandler?.Invoke(sender, new ButtonCBEventArgs(pressed != 0, x, y, EventUtils.StringToModifierStatus(status)));
            return 0;
        }*/

        #endregion BUTTON_CB


        public IcallbackButtonCB ButtonCB
        {
            get
            {
                IntPtr cb = IupGetCallback(Handle, "BUTTON_CB");
                if (cb == IntPtr.Zero) return null;
                return Marshal.GetDelegateForFunctionPointer<IcallbackButtonCB>(cb);
            }

            set
            {
                //IntPtr funcptr=Marshal.GetFunctionPointerForDelegate(value);
                IupSetCallback(Handle, "BUTTON_CB", value);
            }
        }

        public Icallback Action {

            get
            {
                IntPtr cb = IupGetCallback(Handle, "ACTION");
                if (cb == IntPtr.Zero) return null;
                return Marshal.GetDelegateForFunctionPointer<Icallback>(cb);
            }

            set
            {
                IupSetCallback(Handle, "ACTION", value);
            }       
        }

    /*

        #region ACTION
        EventHandler<EventArgs> actionHandler;

        public event EventHandler<EventArgs> Action
        {
            add
            {
                actionHandler += value;
                IupSetCallback(Handle, "ACTION", OnAction);

            }
            remove
            {
                actionHandler -= value;
                if (actionHandler == null) IupSetCallback(Handle, "ACTION", (Icallback)null);

            }
        }

        private int OnAction(IntPtr sender)
        {

            actionHandler?.Invoke(sender, EventArgs.Empty);
            return 0;
        }
        #endregion ACTION*/

    }
}
