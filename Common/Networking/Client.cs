using Common.Commands;
using Common.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.Networking {

    public class Client : Common {

        #region Properties
        private TcpClient _ClientObject;
        public TcpClient ClientObject {
            get {
                return _ClientObject;
            }
            set {
                _ClientObject = value;
            }
        }

        private int _ClientID;
        public int ClientID {
            get {
                return _ClientID;
            }
            set {
                _ClientID = value;
            }
        }

        #endregion

        public Client() {
            this.Side = Sides.CLIENT;
            this.ClientObject = new TcpClient();
        }

        public Client(IPAddress ip, int port) {
            this.Side = Sides.CLIENT;
            this.ClientObject = new TcpClient(ip.ToString(), port);
        }

        public void Connect(IPAddress ip, int port) {
            this.CanRun = true;

            this.Subscriber = SubConnect(ip.ToString(), port.ToString());
            this.Subscriber.Subscribe("A");
            Console.WriteLine(String.Format("-- Client Listening at {0}", this.Subscriber.LastEndpoint));

            this.Publisher = PubHost(ip.ToString(), (port-1).ToString());
            Console.WriteLine(String.Format("-- Client Connected at {0}", this.Publisher.LastEndpoint));

            this.MessageListener = new System.Threading.Thread(() => GetMessages(ip, port, this.Subscriber));
            this.MessageListener.Start();
        }

        public void Disconnect() {
            this.CanRun = false;
            this.Publisher.Close();
            this.Subscriber.Close();
            Console.WriteLine("Connection Closed!");
            this.MessageListener.Abort();
            Console.WriteLine("Listener Stopped!");
        }
    }
}
