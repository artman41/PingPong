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
    class Connect : Command {

        public Connect() {
            this.Text = "Connect";
            this.Description = "Connects to a server.";
            this.Usage = new String[] { "/connect [IpAddress] [Port]" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                if (args.Length == 0) {
                    ((Client)sender).Connect(new Server().IP, new Server().DefaultPort);
                }else
                    if (args.Length == 1) {
                        ((Client)sender).Connect(IPAddress.Parse(args[0]), new Server().DefaultPort);
                    } else if(args.Length == 2) {
                    ((Client)sender).Connect(IPAddress.Parse(args[0]), int.Parse(args[1]));
                }
            }catch(Exception e) {
                Methods.Debug(e);
            }
        }

    }
}
