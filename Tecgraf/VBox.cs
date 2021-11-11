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

        public Size Margin
        {
            get
            {
                Iup.GetIntInt(Handle, "MARGIN", out int i1, out int i2);
                return new Size(i1, i2);
            }
            set
            {
                Iup.SetAttribute(Handle, "MARGIN", IupFormat.Size(value));
                
            }
        }

        public Size CMargin
        {
            get
            {
                Iup.GetIntInt(Handle, "CMARGIN", out int i1, out int i2);
                return new Size(i1, i2);
            }
            set
            {
                Iup.SetAttribute(Handle, "CMARGIN", IupFormat.Size(value));

            }
        }

        public int Gap
        {
            get => Iup.GetInt(Handle, "GAP");
            set => Iup.SetInt(Handle, "GAP", value);
        }

        public int CGap
        {
            get => Iup.GetInt(Handle, "CGAP");
            set => Iup.SetInt(Handle, "CGAP", value);
        }

    }
}
