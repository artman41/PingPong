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
    class Clear : Command {

        public Clear() {
            this.Text = "Clear";
            this.Description = "Clears all text on the console.";
            this.Usage = new String[] { "/clear" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
            Console.Clear();
            } catch (Exception e) {
                Methods.Debug(e);

                Console.WriteLine(args);
            }
        }

    }
}
