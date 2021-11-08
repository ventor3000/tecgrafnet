using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{
    public class Element
    {
        public IntPtr Handle;

        protected Element(IntPtr handle)
        {
            this.Handle = handle;
        }

        public void SetAttribute(string name,string value)
        {
            IupNative.IupSetStrAttribute(Handle, name, value);
        }

        public string GetAttribute(string name)
        {
            return IupNative.IupGetAttribute(Handle, name);
        }

        
    }
}
