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
    class Processes : Command {

        public Processes() {
            this.Text = "Processes";
            this.Description = "Gets all running processes.";
            this.Usage = new String[] { "/processes" };
        }

        override public void RunCommand(Object sender, String[] args) {
            Process[] processes = Process.GetProcesses();
            foreach (var item in processes) {
                Console.WriteLine(String.Format("{0} | {1}", item.Id, item.ProcessName));
            }
        }

    }
}
