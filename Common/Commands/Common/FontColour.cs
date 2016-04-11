using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Common.Misc;

namespace Common.Commands.Common {
    class FontColour : Command {

        public FontColour() {
            this.Text = "FontColour";
            this.Description = "Changes the Font Colour of the window.";
            this.Usage = new String[] { "/fontcolour [Colour]" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                if (!(args[0] == "") && !(args[0] == this.GetCommandName()))Console.ForegroundColor = Methods.GetColour(Color.FromName(args[0]));
                //Methods.Debug(args);
            }
            catch(Exception e) {
                Methods.Debug(e);

                Console.WriteLine(args);
            }
        }

    }
}
