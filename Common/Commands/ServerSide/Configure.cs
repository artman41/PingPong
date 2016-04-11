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
    class Configure : Command {

        public Configure() {
            this.Text = "Configure";
            this.Description = "Configures the server.";
            this.Usage = new String[] { "/configure [AmountConnections]", "/configure [AmountConnections] [Port]", "/configure [AmountConnections] [IpAddress]", "/configure [AmountConnections] [IpAddress] [Port]" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                if (args.Length == 1) {
                    ((Server)sender).ConfigureServer(int.Parse(args[0]));
                } else if(args.Length == 2) {
                    try {
                        ((Server)sender).ConfigureServer(int.Parse(args[0]), int.Parse(args[1]));
                    } catch (Exception e) {
                        ((Server)sender).ConfigureServer(int.Parse(args[0]), new IPAddress(Encoding.ASCII.GetBytes(args[1])));
                    }
                } else if(args.Length == 3) {
                    ((Server)sender).ConfigureServer(int.Parse(args[0]), int.Parse(args[2]), new IPAddress(Encoding.ASCII.GetBytes(args[1])));
                }
            } catch(Exception e) {
                Methods.Debug(e);
            }
        }

    }
}
