using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Commands;
using Common.Networking;
using System.IO;

namespace ClientSide {
    class Program : Client{

        static Program x = new Program();

        override protected void run() {
        }

        protected static void Main(string[] args) {
            x.HandleCommand(x, args);
        }
    }
}
