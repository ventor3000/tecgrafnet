using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    unsafe class Program
    {

        static Dialog dlg;
        static Gauge gauge;

        static void Main(string[] args)
        {
            int argc = args.Length;
            string str = null;


            // EnableThemingInScope.EnableThemingInWindows();


            WindowsSpecific.EnableThemingInWindows();

            
            Iup.Open();


            string lang=IupNative.IupGetLanguage();

            dlg = new Dialog("Min dialog",
                new VBox(
                    new Button("Knapp1") { Action = Knapp1Action } ,
                    gauge=new Gauge() { Value = 0.5 },
                    new Button("Knapp2")
                )
            );

            dlg.Show();
            


            // IupNative.IupSetLanguage("PORTUGUESE");

            // string cancel=IupNative.IupGetLanguageString("IUP_CANCEL");



            IupNative.IupMainLoop();
            IupNative.IupClose();
        }

        private static CBRes Knapp1Action(IntPtr sender)
        {
            Iup.VersionShow();
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
