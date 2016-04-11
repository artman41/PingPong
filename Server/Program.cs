using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide {
    class Program : Server {

        static Program x = new Program();

        override protected void run() {
        }

        protected static void Main(string[] args) {
            x.HandleCommand(x, args);
        }
    }
}
