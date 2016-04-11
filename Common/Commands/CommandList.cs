using Common.Commands.ClientSide;
using Common.Commands.Common;
using Common.Commands.ServerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Commands {

    public class CommandList {

        public static readonly Command[] CommonCommands = { new Help(), new FontColour(), new BackColour(), new Clear(), new Exit()};
        public static readonly Command[] ClientCommands = { new Connect(), new Say(), new Disconnect()};
        public static readonly Command[] ServerCommands = { new Start(), new Configure(), new Stop()};

    }
}
