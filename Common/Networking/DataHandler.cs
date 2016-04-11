using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Networking {
   public class DataHandler {

        private String _Messsage;
        public String Message {
            get {
                return _Messsage;
            }
            set {
                _Messsage = value;
            }
        }

        public DataHandler() {

        }

        public DataHandler(String msg) {
            this.Message = msg;
        }

    }
}
