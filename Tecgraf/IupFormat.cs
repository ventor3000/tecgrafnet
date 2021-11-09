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


        public static string Cursor(Cursor cursorname)
        {
            return EnumToAtt<Tecgraf.Cursor>(cursorname,
                "NONE", Tecgraf.Cursor.None,
                "NULL", Tecgraf.Cursor.None,
                "ARROW", Tecgraf.Cursor.Arrow,
                "BUSY", Tecgraf.Cursor.Busy,
                "CROSS", Tecgraf.Cursor.Cross,
                "HAND", Tecgraf.Cursor.Hand,
                "HELP", Tecgraf.Cursor.Help,
                "MOVE", Tecgraf.Cursor.Move,
                "PEN", Tecgraf.Cursor.Pen,
                "RESIZE_N", Tecgraf.Cursor.ResizeN,
                "RESIZE_S", Tecgraf.Cursor.ResizeS,
                "RESIZE_NS", Tecgraf.Cursor.ResizeNS,
                "RESIZE_W", Tecgraf.Cursor.ResizeW,
                "RESIZE_E", Tecgraf.Cursor.ResizeE,
                "RESIZE_WE", Tecgraf.Cursor.ResizeWE,
                "RESIZE_NE", Tecgraf.Cursor.ResizeNE,
                "RESIZE_SW", Tecgraf.Cursor.ResizeSW,
                "RESIZE_NW", Tecgraf.Cursor.ResizeNW,
                "RESIZE_SE", Tecgraf.Cursor.ResizeSE,
                "TEXT", Tecgraf.Cursor.Text,
                "APPSTARTING", Tecgraf.Cursor.AppStarting,
                "NO", Tecgraf.Cursor.No,
                "UPARROW", Tecgraf.Cursor.UpArrow);

        }

        static T AttToEnum<T>(string attname, params object[] str_obj)
        {
            for (int i = 0; i < str_obj.Length; i += 2)
            {
                if (object.Equals(str_obj[i], attname))
                    return (T)str_obj[i + 1];
            }

            throw new Exception(attname + " attribute could not be mapped");
        }

        static string EnumToAtt<T>(T _enum, params object[] str_obj)
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
