using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{
    public class Canvas:Control
    {
        public Canvas() : base(IupNative.IupCanvas(null))
        {
            
        }
    }
}
