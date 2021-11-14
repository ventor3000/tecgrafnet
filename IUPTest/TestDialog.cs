using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tecgraf;

namespace IUPTest
{
    public class TestDialog:Dialog
    {
        public TestDialog():base("Min dialog",null)
        {
            Append(
                new VBox(
                    new Button("Min dumma knapp") { FgColor = Color.Red,Alignment=Alignment.Right,Expand=Expand.Yes,Padding=new Size(10,10) },
                    new Button("Stäng") { CBAction=delegate { Hide();return CBRes.Default; } }
                )
            );
        }
    }
}
