using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static Tecgraf.IupNative;

namespace Tecgraf
{
    public class VBox:Container
    {

        public VBox(params Control[] children):base(IupNative.IupVbox(IntPtr.Zero))
        {
            foreach (Control c in children)
                Append(c);
        }

        public Size Margin
        {
            get
            {
                IupGetIntInt(Handle, "MARGIN", out int i1, out int i2);
                return new Size(i1, i2);
            }
            set
            {
                IupSetStrAttribute(Handle, "MARGIN", IupFormat.Size(value));
                
            }
        }

        public Size CMargin
        {
            get
            {
                IupGetIntInt(Handle, "CMARGIN", out int i1, out int i2);
                return new Size(i1, i2);
            }
            set
            {
                IupSetStrAttribute(Handle, "CMARGIN", IupFormat.Size(value));

            }
        }

        public int Gap
        {
            get => IupGetInt(Handle, "GAP");
            set => IupSetInt(Handle, "GAP", value);
        }

        public int CGap
        {
            get => IupGetInt(Handle, "CGAP");
            set => IupSetInt(Handle, "CGAP", value);
        }

    }
}
