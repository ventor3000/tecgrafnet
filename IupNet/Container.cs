using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{
    public class Container:Control
    {
        internal Container(IntPtr handle):base(handle)
        {

        }

        public void Append(Control child)
        {
            IupNative.IupAppend(Handle, child.Handle);
        }
    }
}
