using System;
using System.Collections.Generic;
using System.Text;
using static Tecgraf.IupNative;

namespace Tecgraf
{
    public static class Iup
    {
        public static IupError Open()
        {
            WindowsSpecific.AddNativeDllPath();

            int argc = 0;
            string argv = string.Empty;
            return IupOpen(ref argc, ref argv);
        }
    }
}
