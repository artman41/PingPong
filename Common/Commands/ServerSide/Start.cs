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
    class Start : Command {

        public Start() {
            this.Text = "Start";
            this.Description = "Starts the server.";
            this.Usage = new String[] { "/start" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                if (args.Length == 0) {
                    ((Server)sender).StartServer();
                } else if (args.Length == 1) {
                    ((Server)sender).StartServer(IPAddress.Parse(args[0]));
                } else if (args.Length == 2) {
                    ((Server)sender).StartServer(IPAddress.Parse(args[0]), int.Parse(args[1]));
                } else {
                    throw new ArgumentOutOfRangeException("Too many arguments! Please look at the usage of the command! (/help " + this.GetCommandName() + ")", new Exception());
                }
            }catch(Exception e) {
                Methods.Debug(e);
            }
        }

    }
}
