using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Tecgraf
{
    public static class IupFormat
    {

        public static string Int(int v)
        {
            return v.ToString(CultureInfo.InvariantCulture);
        }

        public static string Size(Size s)
        {
            return Int(s.Width) + "x" + Int(s.Height);
        }

        public static string Color(Color value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Int(value.R));
            sb.Append(' ');
            sb.Append(Int(value.G));
            sb.Append(' ');
            sb.Append(Int(value.B));
            return sb.ToString();
        }

        public static string Point(Point pt, string separator = ":")
        {
            return Int(pt.X) + separator + Int(pt.Y);
        }


        public static string Cursor(MouseCursor cursorname)
        {
            return EnumToAtt<Tecgraf.MouseCursor>(cursorname,
                "NONE", Tecgraf.MouseCursor.None,
                "NULL", Tecgraf.MouseCursor.None,
                "ARROW", Tecgraf.MouseCursor.Arrow,
                "BUSY", Tecgraf.MouseCursor.Busy,
                "CROSS", Tecgraf.MouseCursor.Cross,
                "HAND", Tecgraf.MouseCursor.Hand,
                "HELP", Tecgraf.MouseCursor.Help,
                "MOVE", Tecgraf.MouseCursor.Move,
                "PEN", Tecgraf.MouseCursor.Pen,
                "RESIZE_N", Tecgraf.MouseCursor.ResizeN,
                "RESIZE_S", Tecgraf.MouseCursor.ResizeS,
                "RESIZE_NS", Tecgraf.MouseCursor.ResizeNS,
                "RESIZE_W", Tecgraf.MouseCursor.ResizeW,
                "RESIZE_E", Tecgraf.MouseCursor.ResizeE,
                "RESIZE_WE", Tecgraf.MouseCursor.ResizeWE,
                "RESIZE_NE", Tecgraf.MouseCursor.ResizeNE,
                "RESIZE_SW", Tecgraf.MouseCursor.ResizeSW,
                "RESIZE_NW", Tecgraf.MouseCursor.ResizeNW,
                "RESIZE_SE", Tecgraf.MouseCursor.ResizeSE,
                "TEXT", Tecgraf.MouseCursor.Text,
                "APPSTARTING", Tecgraf.MouseCursor.AppStarting,
                "NO", Tecgraf.MouseCursor.No,
                "UPARROW", Tecgraf.MouseCursor.UpArrow);

        }

        

        public static T AttToEnum<T>(string attname, params object[] str_obj)
        {
            for (int i = 0; i < str_obj.Length; i += 2)
            {
                if (object.Equals(str_obj[i], attname))
                    return (T)str_obj[i + 1];
            }

            throw new Exception(attname + " attribute could not be mapped");
        }

        public static string EnumToAtt<T>(T _enum, params object[] str_obj)
        {
            for (int i = 0; i < str_obj.Length; i += 2)
            {
                if (object.Equals(str_obj[i + 1], _enum))
                    return (string)str_obj[i];
            }

            throw new Exception(_enum.ToString() + " attribute could not be unmapped");
        }
    }

    


}
