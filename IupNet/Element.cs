using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    public class Element:IDisposable
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

        public void Dispose()
        {
            // We dont care for a full destructor-type dispose, just destroy self if Dispose is called...
            Destroy();
        }

        virtual protected Icallback CBLDesroy
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

        protected static IntPtr SafeHandle(Element e)
        {
            if (e == null) return IntPtr.Zero;
            return e.Handle;
        }


        protected bool GetBool(string attname)
        {
            string s = Iup.GetAttribute(Handle,attname);
            if (s == "TRUE" || s == "YES" || s == "ON")
                return true;
            return false;
        }

        protected Point GetPoint(string attname)
        {
            int x, y;
            Iup.GetIntInt(Handle,attname, out x, out y);
            return new Point(x, y);
        }

        protected Size GetSize(string attname)
        {
            int x, y;
            Iup.GetIntInt(Handle,attname, out x, out y);
            return new Size(x, y);
        }


        protected void SetBool(string attname, bool value, string trueval, string falseval)
        {
            Iup.SetAttribute(Handle,attname, value ? trueval : falseval);
        }


    }
}
