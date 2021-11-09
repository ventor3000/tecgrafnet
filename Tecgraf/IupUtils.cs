using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{
    public static class IupUtils
    {
       
    }

    public class ModifierStatus
    {

        public readonly bool Shift;
        public readonly bool Control;
        public readonly bool LeftButton;
        public readonly bool MiddleButton;
        public readonly bool RightButton;
        public readonly bool DoubleClick;
        public readonly bool Alt;
        public readonly bool System;
        public readonly bool Button4;
        public readonly bool Button5;

        internal ModifierStatus(string _s)
        {

            Shift = (_s[0] == 'S');
            Control = (_s[1] == 'C'); 
            LeftButton = (_s[2] == '1');
            MiddleButton = (_s[3] == '2');
            RightButton = (_s[4] == '3');
            DoubleClick = (_s[5] == 'D');
            Alt = (_s[6] == 'A');
            System = (_s[7] == 'Y');
            Button4 = (_s[8] == '4');
            Button5 = (_s[9] == '5');
        }

        public override string ToString()
        {
            List<string> parts = new List<string>();
            if (Shift) parts.Add("Shift");
            if (Control) parts.Add("Control");
            if (LeftButton) parts.Add("LeftButton");
            if (MiddleButton) parts.Add("MiddleButton");
            if (RightButton) parts.Add("RightButton");
            if (DoubleClick) parts.Add("DoubleClick");
            if (Alt) parts.Add("Alt");
            if (System) parts.Add("System");
            if (Button4) parts.Add("Button4");
            if (Button5) parts.Add("Button5");

            if (parts.Count == 0)
                return "None";
            else
                return string.Join(',', parts);
            
        }
    }
}
