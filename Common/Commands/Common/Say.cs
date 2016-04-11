using Common.Misc;
using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Commands.Common {
    class Say : Command {

        public Say() {
            this.Text = "Say";
            this.Description = "Sends a message to a server.";
            this.Usage = new String[] { "/say [Message]" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                if(((Networking.Common)sender).Side == Sides.CLIENT) {
                    ((Client)sender).PubSend(((Client)sender).Publisher, args);
                } else {
                    ((Server)sender).PubSend(((Server)sender).Publisher, args);
                }
            } catch(Exception e) {
                Methods.Debug(e);
            }
        }

    }
}
