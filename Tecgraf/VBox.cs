using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Tecgraf
{
    public class VBox:Container
    {

        public VBox(params Control[] children):base(IupNative.IupVbox(IntPtr.Zero))
        {
            foreach (Control c in children)
                Append(c);
        }

        /*public Size Margin
        {
            
        }*/

    }
}
