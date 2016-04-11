using Common.Misc;
using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Commands.ServerSide {
    class Stop : Command {

        public Stop() {
            this.Text = "Stop";
            this.Description = "Stops the server.";
            this.Usage = new String[] { "/stop" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                ((Server)sender).StopServer();
            }catch(Exception e) {
                Methods.Debug(e);
            }
        }

    }
}
