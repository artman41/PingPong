using Common.Misc;
using Common.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Commands {
    public class CommandParsing {

        private Sides _Side;
        public Sides Side {
            get {
                return _Side;
            }
            set {
                _Side = value;
            }
        }

        public CommandParsing() {
        }

        public CommandParsing(Sides s) {
            Side = s;
        }

        public void ParseMessage(Object sender, String s) {

            try {
                try {
                    //Methods.Debug(s.Split(" ".ToCharArray()));
                    String[] x;
                    if (s == "") {
                        x = new String[1] { "/" };
                    } else {
                        x = s.Substring(1).Split(" ".ToCharArray());
                    }
                    String[] y = new String[x.Length - 1];
                    for (int i = 1; i < x.Length; i++) {
                        y[i - 1] = x[i].ToLower();
                    }

                    if (s.StartsWith("/")) GetCommand(x[0]).RunCommand(sender, y);
                } catch (IndexOutOfRangeException e) {
                    if (s.StartsWith("/")) GetCommand(s.Substring(1)).RunCommand(sender, new String[0]);
                }
            } catch (NullReferenceException e) {
                //Methods.Debug(e);
                ConsoleColor fc = Console.ForegroundColor;
                ConsoleColor bc = Console.BackgroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Incorrect Command!");
                Console.ForegroundColor = fc;
                Console.BackgroundColor = bc;
            }
        }

        private Command GetCommand(String s) {
            for (int i = 0; i < CommandList.CommonCommands.Length; i++) {
                if (CommandList.CommonCommands[i].GetCommandName() == s) {
                    return CommandList.CommonCommands[i];
                }
            }

            for (int i = 0; i < CommandList.ClientCommands.Length; i++) {
                if (CommandList.ClientCommands[i].GetCommandName() == s) {
                    return CommandList.ClientCommands[i];
                }
            }

            for (int i = 0; i < CommandList.ServerCommands.Length; i++) {
                if (CommandList.ServerCommands[i].GetCommandName() == s) {
                    return CommandList.ServerCommands[i];
                }
            }

            return null;
        }

    }
}
