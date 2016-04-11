using Common.Misc;
using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Commands.ClientSide {
    class Disconnect : Command {

        public Disconnect() {
            this.Text = "Disconnect";
            this.Description = "Disconnect from a server.";
            this.Usage = new String[] { "/disconnect" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                ((Client)sender).Disconnect();
            }catch(Exception e) {
                Methods.Debug(e);
            }
        }

    }
}
