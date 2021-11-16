using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecgraf;

namespace IupTestNetFramework
{
    unsafe class Program
    {

        static Dialog dlg;
        static Gauge gauge;

        static void Main(string[] args)
        {
            int argc = args.Length;


            // EnableThemingInScope.EnableThemingInWindows();

            WindowsVisualStyles.Enable();



            Iup.Open();


            string lang = Iup.GetLanguage();

            dlg = new Dialog("Min dialog",
                new VBox(
                    new Button("Knapp1") { CBAction = Knapp1Action, Expand = Expand.Yes },
                    gauge = new Gauge() { Value = 0.5, Expand = Expand.Horizontal },
                    new Button("Knapp2")
                )
                { Margin = new Size(10, 10), Gap = 4 }
            );

            dlg.Expand = Expand.Yes;


            dlg.Show();



            string[] names = Iup.GetClassCallbacks("button");





            // IupNative.IupSetLanguage("PORTUGUESE");

            // string cancel=IupNative.IupGetLanguageString("IUP_CANCEL");



            Iup.MainLoop();




            Iup.Close();
        }

        private static CBRes Knapp1Action(IntPtr sender)
        {

            /*using*/
            FileDialog dlg = new FileDialog() { DialogType = FileDialogType.Open, CBFile = OnFile };

            dlg.Popup(100, 100);




            return CBRes.Default;
        }

        private static CBRes OnFile(IntPtr* sender, string file_name, string status)
        {
            Iup.Message(file_name, status);
            return CBRes.Default;
        }

        private static CBRes ViewportMotion(IntPtr sender, int x, int y, ModifierStatus status)
        {
            dlg.Title = x.ToString() + " " + y.ToString() + " " + status.ToString();
            return CBRes.Default;
        }

        private static CBRes MyKnapp(IntPtr sender, MouseButton button, bool pressed, int x, int y, ModifierStatus status)
        {
            dlg.Title = button.ToString() + (pressed ? " Down " : " Up ") + status.ToString();

            return CBRes.Ignore;

        }


        private static CBRes Knapp1_Action(IntPtr sender)
        {


            return 0;
        }

        private static void Dlg_MoveCB(object sender, MoveCBEventArgs e)
        {
            Iup.SetAttribute((IntPtr)sender, "TITLE", e.X.ToString() + " " + e.Y.ToString());
        }





    }
}
