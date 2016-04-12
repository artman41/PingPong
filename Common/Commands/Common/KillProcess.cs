using Common.Misc;
using Common.Networking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Commands.Common {
    class KillProcess : Command {

        public KillProcess() {
            this.Text = "KillProcess";
            this.Description = "Kills the running process.";
            this.Usage = new String[] { "/killprocess [pid]" };
        }

        override public void RunCommand(Object sender, String[] args) {
            try {
                Process.GetProcessById(int.Parse(args[0])).Kill();
            } catch (Exception e) {
                Console.WriteLine(String.Format("Error: {0}, Stacktrace: {1}", e.Data, e.StackTrace));
            }
        }

    }
}
