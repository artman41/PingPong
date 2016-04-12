using Common.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Commands;
using System.Net;
using System.Net.Sockets;

namespace Common.Networking {

    public class Server : Common {

        #region Properties
        private int _AmountConnections;
        public int AmountConnections {
            get {
                return _AmountConnections;
            }
            set {
                _AmountConnections = value;
            }
        }

        private int _CurrentConnections;
        public int CurrentConnections {
            get {
                return _CurrentConnections;
            }
            set {
                _CurrentConnections = value;
            }
        }

        private bool _IsHosting;
        public bool IsHosting {
            get {
                return _IsHosting;
            }
            set {
                _IsHosting = value;
            }
        }

        private int _Port;
        public int Port {
            get {
                return _Port;
            }
            set {
                _Port = value;
            }
        }

        private IPAddress _IP;
        public IPAddress IP {
            get {
                return _IP;
            }
            set {
                _IP = value;
            }
        }

        private bool _AlreadyListening;
        private bool AlreadyListening {
            get {
                return _AlreadyListening;
            }
            set {
                _AlreadyListening = value;
            }
        }

        private List<int> _ConnectedIDs = new List<int>();
        public List<int> ConnectedIDs {
            get {
                return _ConnectedIDs;
            }
            set {
                _ConnectedIDs = value;
            }
        }

        #endregion

        #region  Instantiation

        public Server() {
            this.Side = Sides.SERVER;
            this.Port = this.DefaultPort;
            this.IP = IPAddress.Parse("127.0.0.1");
        }

        public Server(int AmountConnections, int port, IPAddress ip) {
            this.Side = Sides.SERVER;
            ConfigureServer(AmountConnections, port, ip);

        }

        public Server(int AmountConnections, IPAddress ip) {
            this.Side = Sides.SERVER;
            ConfigureServer(AmountConnections, ip);
        }

        public Server(int AmountConnections, int port) {
            this.Side = Sides.SERVER;
            ConfigureServer(AmountConnections, port);
        }

        public Server(int AmountConnections) {
            this.Side = Sides.SERVER;
            ConfigureServer(AmountConnections);
        }

        #endregion

        #region Configure_Server
        public void ConfigureServer(int AmountConnections, int port, IPAddress ip) {
            this.AmountConnections = AmountConnections;
            this.Port = port;
            this.IP = ip;
        }

        public void ConfigureServer(int AmountConnections, IPAddress ip) {
            this.AmountConnections = AmountConnections;
            this.Port = this.DefaultPort;
            this.IP = ip;
        }

        public void ConfigureServer(int AmountConnections, int port) {
            this.AmountConnections = AmountConnections;
            this.Port = port;
            this.IP = IPAddress.Any;
        }

        public void ConfigureServer(int AmountConnections) {
            this.AmountConnections = AmountConnections;
            this.Port = this.DefaultPort;
            this.IP = IPAddress.Any;
        }
        #endregion

        public void StartServer() {
            this.CanRun = true;

            this.Subscriber = SubConnect(this.IP.ToString(), (this.Port - 1).ToString());
            this.Subscriber.Subscribe("A");
            Console.WriteLine(String.Format("-- Server Listening at {0}", this.Subscriber.LastEndpoint));

            this.Publisher = PubHost(this.IP.ToString(), this.Port.ToString());
            Console.WriteLine(String.Format("-- Server Hosted at {0}", this.Publisher.LastEndpoint));

            this.MessageListener = new System.Threading.Thread(() => GetMessages(this.IP, this.Port-1, this.Subscriber));
            this.MessageListener.Start();
        }

        public void StartServer(IPAddress ip) {
            this.ConfigureServer(this.AmountConnections, ip);
            this.StartServer();
        }

        public void StartServer(IPAddress ip, int port) {
            this.ConfigureServer(this.AmountConnections, port, ip);
            this.StartServer();
        }

        public void StopServer() {
            this.CanRun = false;
            this.Publisher.Close();
            this.Subscriber.Close();
            Console.WriteLine("Server Closed!");
            this.MessageListener.Abort();
            Console.WriteLine("Listener Stopped!");
        }

        public void AddClient(Client ConnectingClient) {
            List<int> x = this.ConnectedIDs;
            x.Add(ConnectingClient.ClientID);
            this.ConnectedIDs = x;
        }

        public void RemoveClient(Client DisconnectingClient) {
            List<int> x = this.ConnectedIDs;
            x.RemoveAt(x.FindIndex(y => y == DisconnectingClient.ClientID));
            this.ConnectedIDs = x;
        }

    }
}
