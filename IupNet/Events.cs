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


}
