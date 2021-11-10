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


    public enum FileStatus
    {
        Cancel = -1,
        ExistingFile = 0,
        NewFile = 1
    }


    /*
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
    }*/





    public enum Expand
    {
        Yes,
        No,
        Horizontal,
        Vertical,
    }

    public enum Cursor
    {
        None,
        Arrow,
        Busy,
        Cross,
        Hand,
        Help,
        Move,
        Pen,
        ResizeN,
        ResizeS,
        ResizeNS,
        ResizeW,
        ResizeE,
        ResizeWE,
        ResizeNE,
        ResizeSW,
        ResizeNW,
        ResizeSE,
        Text,
        /// <summary>
        /// Windows only
        /// </summary>
        AppStarting,
        /// <summary>
        /// Windows only
        /// </summary>
        No,
        UpArrow
    }

    public enum CBRes
    {
        Ignore=-1,
        Default=-2,
        Close=-3,
        Continue=-4
    }

    public enum MessageButtons
    {
        Ok,
        OkCancel,
        RetryCancel,
        YesNo,
        YesNoCancel
    }


    public enum RecordInputMode
    {
        Binary=0,
        Text=1
    }
     


}
