using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    public class Canvas:Control
    {
        public Canvas() : base(IupNative.IupCanvas(null))
        {
            
        }



        #region CALLBACKS

        public IcallbackMotionCB MotionCB
        {
            get
            {
                IntPtr cb = Iup.GetCallback(Handle, "MOTION_CB");
                if (cb == IntPtr.Zero) return null;
                return Marshal.GetDelegateForFunctionPointer<IcallbackMotionCB>(cb);
            }

            set
            {
                //IntPtr funcptr=Marshal.GetFunctionPointerForDelegate(value);
                Iup.SetCallback(Handle, "MOTION_CB", value);
            }
        }

        #endregion CALLBACKS
    }
}
