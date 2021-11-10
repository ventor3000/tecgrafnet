using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    unsafe class Program
    {

        static Dialog dlg;

        static void Main(string[] args)
        {
            int argc = args.Length;
            string str = null;


            // EnableThemingInScope.EnableThemingInWindows();


            WindowsSpecific.EnableThemingInWindows();

            
            Iup.Open();


            string lang=IupNative.IupGetLanguage();

            // IupNative.IupSetLanguage("PORTUGUESE");

            // string cancel=IupNative.IupGetLanguageString("IUP_CANCEL");



            
            

            IupNative.IupMainLoop();


            bool op=IupNative.IupIsOpened();
            IupNative.IupClose();

            op = IupNative.IupIsOpened();


        }

        private static CBRes Knapp1Action(IntPtr sender)
        {
            Color c = Color.Red;
            if (Iup.GetColor(100, 100, ref c))
                Iup.Message(c.ToString()); 
            
            return CBRes.Default;
        }

        private static CBRes ViewportMotion(IntPtr sender, int x, int y, ModifierStatus status)
        {
            dlg.Title = x.ToString() + " " + y.ToString() + " " + status.ToString();
            return CBRes.Default;
        }

        private static CBRes MyKnapp(IntPtr sender, MouseButton button, bool pressed, int x, int y, ModifierStatus status)
        {
            dlg.Title = button.ToString()+(pressed?" Down ":" Up ") + status.ToString();
            
            return CBRes.Ignore;

        }

        
        private static CBRes Knapp1_Action(IntPtr sender)
        {
            

            return 0;
        }

        private static void Dlg_MoveCB(object sender, MoveCBEventArgs e)
        {
            IupNative.IupSetStrAttribute((IntPtr)sender, "TITLE", e.X.ToString() + " " + e.Y.ToString());
        }

       


        
    }
}
