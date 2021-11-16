using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;



namespace Tecgraf
{
    public class Control:Element
    {
        internal Control(IntPtr handle):base(handle)
        {

        }


        #region ATTRIBUTES

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
                    case Expand.Vertical: Iup.SetAttribute(Handle, "EXPAND", "VERTICAL");return;
                    case Expand.Horizontal: Iup.SetAttribute(Handle, "EXPAND", "HORIZONTAL"); return;
                    case Expand.Yes: Iup.SetAttribute(Handle, "EXPAND", "YES"); return;
                    case Expand.No: Iup.SetAttribute(Handle, "EXPAND", "NO"); return;
                }
            }
        }

        public virtual Color BgColor
        {
            set
            {
                Iup.SetAttribute(Handle,"BGCOLOR", IupFormat.Color(value));
            }
            get
            {
                return IupParse.Color(Iup.GetAttribute( Handle,Iup.GetAttribute(Handle,"BGCOLOR")));
            }
        }

        public virtual Color FgColor
        {
            set
            {
                Iup.SetAttribute(Handle, "FGCOLOR", IupFormat.Color(value));
            }
            get
            {
                return IupParse.Color(Iup.GetAttribute(Handle, Iup.GetAttribute(Handle, "FGCOLOR")));
            }
        }

        #endregion


        #region FUNCTIONS
        public virtual void Hide() => Iup.Hide(Handle);
        public virtual IupError Show() => Iup.Show(Handle);
        #endregion


    }

    
}
