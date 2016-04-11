using Common.Misc;
using Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Networking {

    public enum Sides {CLIENT, SERVER};

    public class Side {

        private Sides _Type;
        public Sides Type {
            get {
                return _Type;
            }
            set {
                _Type = value;
            }
        }

        public Side(CommandParsing type, DataHandler dh) {

        }

    }
}
