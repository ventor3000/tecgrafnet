using System;
using System.Drawing;
using System.Runtime.InteropServices;



namespace Tecgraf
{
    unsafe class Program
    {
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

            





            Button knapp1;
            Dialog dlg = new Dialog("My dialog",
                new VBox(
                    knapp1 = new Button("Knapp 1") { Expand = Expand.Horizontal,ButtonCB= MyKnapp },
                    new Button("Knapp 2") { Expand = Expand.Horizontal },
                    new Canvas() { Expand = Expand.Yes },
                    new Button("Knapp 3") { Expand = Expand.Horizontal }
                )
                { Margin = new Size(8,8),Gap=4 }
            )
            { Expand = Expand.Yes };

            
            //IupNative.Set


            dlg.Show();

            
            

            IupNative.IupMainLoop();


            bool op=IupNative.IupIsOpened();
            IupNative.IupClose();

            op = IupNative.IupIsOpened();


        }

        private static CBRes MyKnapp(IntPtr sender, int button, bool pressed, int x, int y, ModifierStatus status)
        {
            if (!pressed)
            {
                int dd = 0;
            }
            
            return CBRes.Default;

        }

        
        private static CBRes Knapp1_Action(IntPtr sender)
        {
            IupNative.IupMessage("Hello", "World");

            return 0;
        }

        private static void Dlg_MoveCB(object sender, MoveCBEventArgs e)
        {
            IupNative.IupSetStrAttribute((IntPtr)sender, "TITLE", e.X.ToString() + " " + e.Y.ToString());
        }

        private static void Dlg_ButtonCB(object sender, ButtonCBEventArgs e)
        {
            
        }

        private static void Btn_BUTTON_CB1(object sender, ButtonCBEventArgs e)
        {
            ///   IUPNative.IupMessage("Meddelande", "knapp");
         //   IUPNative.IupSetStrAttribute((IntPtr)sender, "EXPAND", "YES");

            //IUPNative.IupSetStrAttribute((IntPtr)sender, "TITLE", e.ModifierStatus.ToString());

            IupNative.IupExitLoop();
        }



        
    }
}
