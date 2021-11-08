using System;
using System.Collections.Generic;
using System.Text;

using static Tecgraf.IupNative;


namespace Tecgraf
{
    public class Control:Element
    {
        internal Control(IntPtr handle):base(handle)
        {

        }


       public Expand Expand
        {
            get
            {
                string exp = GetAttribute("EXPAND");
                switch(exp)
                {
                    case "YES":return Expand.Yes;
                    case "NO": return Expand.No;
                    case "HORIZONTAL": return Expand.Horizontal;
                    case "VERTICAL": return Expand.Vertical;
                }

                return Expand.No;                
            }

            set
            {
                switch(value)
                {
                    case Expand.Vertical: IupSetStrAttribute(Handle, "EXPAND", "VERTICAL");return;
                    case Expand.Horizontal: IupSetStrAttribute(Handle, "EXPAND", "HORIZONTAL"); return;
                    case Expand.Yes: IupSetStrAttribute(Handle, "EXPAND", "YES"); return;
                    case Expand.No: IupSetStrAttribute(Handle, "EXPAND", "NO"); return;
                }
            }
        }


      
    }

    
}
