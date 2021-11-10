using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{
    public class Gauge:Control
    {
        public Gauge():base(Iup.Gauge())
        {

        }

        public double Value
        {
            get => IupNative.IupGetDouble(Handle, "VALUE");
            set => IupNative.IupSetDouble(Handle, "VALUE", value);
        }

        public string Text
        {
            get => IupNative.IupGetAttribute(Handle, "TEXT");
            set => IupNative.IupSetStrAttribute(Handle, "TEXT", value ?? "");
        }
    }
}
