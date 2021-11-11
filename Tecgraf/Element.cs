using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    public class Element
    {
        public IntPtr Handle;

        static Dictionary<IntPtr, Element> elementMap = new Dictionary<IntPtr, Element>();

        internal Element(IntPtr handle)
        {
            this.Handle = handle;
            elementMap[handle] = this;

            CBLDesroy = OnElementDestroyed;
        }

        private CBRes OnElementDestroyed(IntPtr sender)
        {
            string str = Iup.GetClassName(sender);
            
            if(elementMap.ContainsKey(sender)) 
                elementMap.Remove(sender);
            return CBRes.Default;
        }

        public void SetAttribute(string name,string value)
        {
            IupNative.IupSetStrAttribute(Handle, name, value);
        }

        public string GetAttribute(string name)
        {
            return IupNative.IupGetAttribute(Handle, name);
        }

        public void Destroy()
        {
            if (Handle != IntPtr.Zero)
            {
                var h = Handle;
                Handle = IntPtr.Zero;
                Iup.Destroy(h);
            }
        }

        public Icallback CBLDesroy
        {

            get
            {
                IntPtr cb = Iup.GetCallback(Handle, "LDESTROY_CB");
                if (cb == IntPtr.Zero) return null;
                return Marshal.GetDelegateForFunctionPointer<Icallback>(cb);
            }
            set
            {
                Iup.SetCallback(Handle, "LDESTROY_CB", value);
            }
        }


    }
}
