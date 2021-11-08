using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{


    public enum IupError {
        NoError = 0,
        Error = 1,
        Opened = -1,
        Invalid = -1,
        InvalidID = -10
    }


    public enum MouseButton
    {
        Left=49,
        Middle=50,
        Right=51
    }

    [Flags]
    public enum ModifierStatus
    {
        None=0,
        Shift = 1,
        Control = 2,
        LeftButton = 4,
        MiddleButton = 8,
        RightButton = 16,
        DoubleClick = 32,
        Alt = 64,
        System = 128,
        Button4 = 256,
        Button5 = 512
    }


    public enum Expand
    {
        Yes,
        No,
        Horizontal,
        Vertical,
    }


    

}
