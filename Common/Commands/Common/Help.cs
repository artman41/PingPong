using Common.Misc;
using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Commands.Common {
    class Help : Command {

        public Help() {
            this.Text = "Help";
            this.Description = "Returns all available Commands. Can also be used to see the Description of Commands and their Usage.";
            this.Usage = new String[]{"/help", "/help [Command]" };
        }

        override public void RunCommand(Object sender, String[] args) {
            if (args.Length == 0) {

                Console.WriteLine(((Networking.Common)sender).Side + ">> " + "These are the available commands: ");

                if (((Networking.Common)sender).Side.Equals(Sides.CLIENT)) {
                    for (int i = 0; i < CommandList.ClientCommands.Length; i++) {
                        Console.WriteLine(" -> " + CommandList.ClientCommands[i].Text);
                    }
                } else {
                    for (int i = 0; i < CommandList.ServerCommands.Length; i++) {
                        Console.WriteLine(" -> " + CommandList.ServerCommands[i].Text);
                    }
                }

                for (int i = 0; i < CommandList.CommonCommands.Length; i++) {
                    Console.WriteLine(" -> " + CommandList.CommonCommands[i].Text);
                }

            }else {
                bool foundCommand = false;
                for (int i = 0; i < CommandList.CommonCommands.Length; i++) {
                    if (CommandList.CommonCommands[i].GetCommandName() == args[0] && !foundCommand) {
                        Console.WriteLine("Description:  " + CommandList.CommonCommands[i].Description);
                        Methods.WriteArray("Usage:  ", CommandList.CommonCommands[i].Usage);
                        foundCommand = true;
                    }
                }

                if (((Networking.Common)sender).Side.Equals(Sides.CLIENT)) {
                    for (int i = 0; i < CommandList.ClientCommands.Length; i++) {
                        if (CommandList.ClientCommands[i].GetCommandName() == args[0] && !foundCommand) {
                            Console.WriteLine("Description: " + CommandList.ClientCommands[i].Description);
                            Methods.WriteArray("Usage: ", CommandList.ClientCommands[i].Usage);
                            foundCommand = true;
                        }
                    }
                } else {
                    for (int i = 0; i < CommandList.ServerCommands.Length; i++) {
                        if (CommandList.ServerCommands[i].GetCommandName() == args[0] && !foundCommand) {
                            Console.WriteLine("Description: " + CommandList.ServerCommands[i].Description);
                            Methods.WriteArray("Usage: ", CommandList.ServerCommands[i].Usage);
                            foundCommand = true;
                        }
                    }
                }

                if (!foundCommand) {
                    Console.WriteLine(" -> " + "Command not found!");
                }
            }
        }

    }
}
