using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Tecgraf
{
    public static class IupParse
    {

        public static Color Color(string cs)
        {
            uint col;
            cs = cs.Trim();
            int r = 0, g = 0, b = 0;

            if (cs.StartsWith("#"))
            {
                r = Convert.ToInt32(cs.Substring(1, 2));
                g = Convert.ToInt32(cs.Substring(3, 2));
                b = Convert.ToInt32(cs.Substring(5, 2));
            }
            else
            {
                string[] rgb = cs.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (rgb.Length > 0)
                    r = Int(rgb[0]);
                if (rgb.Length > 1)
                    g = Int(rgb[1]);
                if (rgb.Length > 2)
                    b = Int(rgb[2]);
            }

            return System.Drawing.Color.FromArgb(255, r, g, b);
        }

        public static int Int(string str)
        {
            int res;
            if (int.TryParse(str, out res))
                return res;
            return 0;
        }

        public static MouseCursor Cursor(string cursorname)
        {
            return IupFormat.AttToEnum<MouseCursor>(cursorname,
                "NONE", MouseCursor.None,
                "NULL", MouseCursor.None,
                "ARROW", MouseCursor.Arrow,
                "BUSY", MouseCursor.Busy,
                "CROSS", MouseCursor.Cross,
                "HAND", MouseCursor.Hand,
                "HELP", MouseCursor.Help,
                "MOVE", MouseCursor.Move,
                "PEN", MouseCursor.Pen,
                "RESIZE_N", MouseCursor.ResizeN,
                "RESIZE_S", MouseCursor.ResizeS,
                "RESIZE_NS", MouseCursor.ResizeNS,
                "RESIZE_W", MouseCursor.ResizeW,
                "RESIZE_E", MouseCursor.ResizeE,
                "RESIZE_WE", MouseCursor.ResizeWE,
                "RESIZE_NE", MouseCursor.ResizeNE,
                "RESIZE_SW", MouseCursor.ResizeSW,
                "RESIZE_NW", MouseCursor.ResizeNW,
                "RESIZE_SE", MouseCursor.ResizeSE,
                "TEXT", MouseCursor.Text,
                "APPSTARTING", MouseCursor.AppStarting,
                "NO", MouseCursor.No,
                "UPARROW", MouseCursor.UpArrow);

        }
    }
}
