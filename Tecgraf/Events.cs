using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{
    public class ButtonCBEventArgs : EventArgs
    {

        public bool Down;
        public int X;
        public int Y;
        public ModifierStatus ModifierStatus;


        public ButtonCBEventArgs(bool down, int x, int y, ModifierStatus ms)
        {
            this.Down = down;
            this.X = x;
            this.Y = y;
            this.ModifierStatus = ms;
        }
    }


    public class MoveCBEventArgs : EventArgs
    {

        public int X;
        public int Y;


        public MoveCBEventArgs(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }


    internal static class EventUtils
    {
        

        internal static ModifierStatus StringToModifierStatus(string _s)
        {
            ModifierStatus res = ModifierStatus.None;
            if (_s[0] == 'S') res |= ModifierStatus.Shift;
            if (_s[1] == 'C') res |= ModifierStatus.Control;
            if (_s[2] == '1') res |= ModifierStatus.LeftButton;
            if (_s[3] == '2') res |= ModifierStatus.MiddleButton;
            if (_s[4] == '3') res |= ModifierStatus.RightButton;
            if (_s[5] == 'D') res |= ModifierStatus.DoubleClick;
            if (_s[6] == 'A') res |= ModifierStatus.Alt;
            if (_s[7] == 'Y') res |= ModifierStatus.System;
            if (_s[8] == '4') res |= ModifierStatus.Button4;
            if (_s[9] == '5') res |= ModifierStatus.Button5;

            return res;
        }
    }


}
