using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;


namespace Tecgraf
{
    public class Button : Control
    {
        public Button(string caption) : base(Iup.Button(caption, string.Empty))
        {
        }



        public virtual Alignment Alignment
        {
            set
            {
                string v = IupFormat.EnumToAtt<Alignment>(value,
                    "ACENTER:ACENTER", Alignment.Center,
                    "ACENTER:ATOP", Alignment.Top,
                    "ALEFT:ACENTER", Alignment.Left,
                    "ARIGHT:ACENTER", Alignment.Right,
                    "ACENTER:ABOTTOM", Alignment.Bottom,
                    "ALEFT:ATOP", Alignment.TopLeft,
                    "ARIGHT:ATOP", Alignment.TopRight,
                    "ALEFT:ABOTTOM", Alignment.BottomLeft,
                    "ARIGHT:ABOTTOM", Alignment.BottomRight);
                Iup.SetAttribute(Handle,"ALIGNMENT", v);
            }
        } //TODO: get


        public virtual bool CanFocus
        {
            get
            {
                return  GetBool("CANFOCUS");
            }
            set
            {
                SetBool("CANFOCUS", value, "YES", "NO");
            }
        }

        public virtual bool Flat
        {
            get
            {
                return GetBool("FLAT");
            }
            set
            {
                SetBool("FLAT", value, "YES", "NO");
            }
        }


        /* TODO: implement glyphs
        public virtual Glyph Glyph
        {
            get
            {
                return _glyph;
            }
            set
            {
                _glyph = value;
                Handle.SetAttributeHandle("IMAGE", value == null ? null : value.Handle);
            }
        }





        public virtual Glyph GlyphInactive
        {
            get
            {
                return _glyphInactive;
            }
            set
            {
                _glyphInactive = value;
                Handle.SetAttributeHandle("IMINACTIVE", value == null ? null : value.Handle);
            }
        }




        public virtual Glyph GlyphPress
        {
            get
            {
                return _glyphPress;
            }
            set
            {
                _glyphPress = value;
                Handle.SetAttributeHandle("IMPRESS", value == null ? null : value.Handle);
            }
        }
        */

        public virtual ImagePosition ImagePosition
        {
            get
            {
                return IupFormat.AttToEnum<ImagePosition>(Iup.GetAttribute(Handle,"IMAGEPOSITION"), "LEFT", ImagePosition.Left, "RIGHT", ImagePosition.Right, "TOP", ImagePosition.Top, "BOTTOM", ImagePosition.Bottom);
            }
            set
            {
                Iup.SetAttribute(Handle,"IMAGEPOSITION", IupFormat.EnumToAtt<ImagePosition>(value, "LEFT", ImagePosition.Left, "RIGHT", ImagePosition.Right, "TOP", ImagePosition.Top, "BOTTOM", ImagePosition.Bottom));
            }
        }

        public virtual Size Padding
        {
            get
            {
                return base.GetSize("PADDING");
            }
            set
            {
                Iup.SetAttribute(Handle,"PADDING", IupFormat.Size(value));
            }
        }

        /// <summary>
        /// (creation only): defines the spacing between the image associated and the button's text. Default: 2.
        /// </summary>
        public virtual int Spacing
        {
            get
            {
                return Iup.GetInt(Handle,"SPACING");
            }
            set
            {
                Iup.SetInt(Handle,"SPACING", value);
            }
        }




        #region CALLBACKS

        public IcallbackButtonCB CBButton
        {
            get
            {
                

                IntPtr cb = Iup.GetCallback(Handle, "BUTTON_CB");
                if (cb == IntPtr.Zero) return null;
                return Marshal.GetDelegateForFunctionPointer<IcallbackButtonCB>(cb);
            }

            set
            {
                //IntPtr funcptr=Marshal.GetFunctionPointerForDelegate(value);
                Iup.SetCallback(Handle, "BUTTON_CB", value);
            }
        }

        public Icallback CBAction {

            get
            {
                IntPtr cb = Iup.GetCallback(Handle, "ACTION");
                if (cb == IntPtr.Zero) return null;
                return Marshal.GetDelegateForFunctionPointer<Icallback>(cb);
            }

            set
            {
                Iup.SetCallback(Handle, "ACTION", value);
            }       
        }


        #endregion


    }
}
