using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Commands.Common {
    class Exit : Command {

        public Exit() {
            this.Text = "Exit";
            this.Description = "Exits the current program.";
            this.Usage = new String[] { "/exit" };
        }

        override public void RunCommand(Object sender, String[] args) {
            Environment.Exit(0);
        }

    }
}
