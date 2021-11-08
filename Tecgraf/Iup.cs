using System;
using System.Collections.Generic;
using System.Text;
using static Tecgraf.IupNative;

namespace Tecgraf
{
    public static class Iup
    {
        public static void Open()
        {
            int argc = 0;
            string argv = string.Empty;
            IupOpen(ref argc, ref argv);
        }
    }
}
