using System;
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


            EnableThemingInScope.EnableThemingInWindows();


            
            Iup.Open();


            string pp=IupNative.IupGetGlobal("DRIVER");

            IupNative.IupVersionShow();

            string ss = IupNative.IupVersionDate();
            IupNative.IupMessage("Version", str);

            Button btn = new Button("Min knapp åäö") { Expand = Expand.Yes };
            Button knapp1;
            Dialog dlg = new Dialog("My dialog",
                new VBox(
                    btn,
                    knapp1=new Button("Knapp 1") { Expand=Expand.Horizontal },
                    new Button("Knapp 2") { Expand = Expand.Yes },
                    new Button("Knapp 3") { Expand = Expand.Yes }
                )
            )
            { Expand = Expand.Yes };

            btn.SetAttribute("TITLE", "hej");

            btn.ButtonCB += Btn_BUTTON_CB1;
            dlg.MoveCB += Dlg_MoveCB;

            dlg.Show();

            knapp1.Action += Knapp1_Action;
            

            IupNative.IupMainLoop();


            bool op=IupNative.IupIsOpened();
            IupNative.IupClose();

            op = IupNative.IupIsOpened();


        }

        private static void Knapp1_Action(object sender, EventArgs e)
        {

            IupNative.IupMessage("Meddelande", IupNative.IupVersion());

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
