using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Commands {
    public class Command {

        protected String _Text;
        public String Text {
            get {
                return _Text;
            }
            set {
                _Text = value;
            }
        }

        protected String[] _Usage;
        public String[] Usage {
            get {
                return _Usage;
            }
            set {
                _Usage = value;
            }
        }

        protected String _Description;
        public String Description {
            get {
                return _Description;
            }
            set {
                _Description = value;
            }
        }

        public String GetCommandName() {
            return Text.ToLower().Replace(" ", "_");
        }

        virtual public void RunCommand(Object sender, String[] args) {
        }

    }
}
