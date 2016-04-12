using Common.Commands;
using Common.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ZeroMQ;

namespace Common.Networking {
    public class Common : CommandParsing {

        protected CommandParsing commandParsing;

        private readonly int _DefaultPort = 10054;
        public int DefaultPort {
            get {
                return _DefaultPort;
            }
        }

        private ZSocket _Publisher;
        public ZSocket Publisher {
            get {
                return _Publisher;
            }
            set {
                _Publisher = value;
            }
        }

        private ZSocket _Subscriber;
        protected ZSocket Subscriber {
            get {
                return _Subscriber;
            }
            set {
                _Subscriber = value;
            }
        }

        private bool _CanRun = false;
        protected bool CanRun {
            get {
                return _CanRun;
            }
            set {
                _CanRun = value;
            }
        }

        private System.Threading.Thread _MessageListener;
        protected System.Threading.Thread MessageListener {
            get {
                return _MessageListener;
            }
            set {
                _MessageListener = value;
            }
        }

        virtual protected void run() {
        }

        public void HandleCommand(Object sender, string[] args) {
            this.run();

            while (true) {
                this.commandParsing = new CommandParsing(this.Side);
                commandParsing.ParseMessage(sender, Console.In.ReadLine());
            }
        }

        protected ZSocket PubHost(String ip, string port) {
            ZSocket publisher = new ZSocket(new ZContext(), ZSocketType.PUB);

                    publisher.Linger = TimeSpan.Zero;

                    if (ip == "") {
                        publisher.Bind("tcp://*:" + port);
                    } else {
                if (ip.StartsWith("192") || ip.StartsWith("172")) {
                    publisher.Bind("tcp://" + ip + ":" + port);
                } else {
                    Console.WriteLine("We do not currently support external IPs");
                    return PubHost(Methods.LocalIPAddress().ToString(), port);
                }
                    }

                    return publisher;
            }

        public void PubSend(ZSocket publisher, String[] data) {
                ZMessage message = new ZMessage();

            message.Add(new ZFrame("A"));
            message.Add(new ZFrame(Methods.LocalIPAddress().ToString()));
                foreach (var item in data) {
                    message.Add(new ZFrame(item));
                }
            //Console.WriteLine("Publishing ", message);
            PrintMessage("LocalHost", message);
            publisher.Send(message);
        }

        protected ZSocket SubConnect(String ip, String port) {
            ZSocket subscriber = new ZSocket(new ZContext(), ZSocketType.SUB);
                    subscriber.Connect("tcp://" + ip + ":" + port);

                    return subscriber;
        }

        protected void SubRecieve(ZSocket subscriber) {
            try {
                var message = subscriber.ReceiveMessage();

                PrintMessage(message);
            } catch (Exception e) {

            }
        }

        protected void GetMessages(IPAddress ip, int port, ZSocket subscriber) {

            int msgCheck = 0;
            while (this.CanRun) {
                msgCheck++;
                //Console.WriteLine("Message Check {0} on Side {1}", msgCheck, this.Side);
                SubRecieve(subscriber);
            }
        }

        private void PrintMessage(ZMessage message) {
            ZMessage msg = (ZMessage)message.Clone();

            string address = msg[1].ToString();
            string contents = "";

            msg.RemoveAt(0);
            msg.RemoveAt(0);

            for (int i = 0; i < msg.Count; i++) {
                if (!(msg[i] == msg[msg.Count - 1])) {
                    contents = contents + msg[i] + " ";
                } else {
                    contents = contents + msg[i];
                }
            }

            Console.WriteLine("[{0}] >> {1}", address, contents);
        }

        private void PrintMessage(String address, ZMessage message) {
            ZMessage msg = (ZMessage)message.Clone();

            string contents = "";

            msg.RemoveAt(0);
            msg.RemoveAt(0);

            for (int i = 0; i < msg.Count; i++) {
                if (!(msg[i] == msg[msg.Count - 1])) {
                    contents = contents + msg[i] + " ";
                } else {
                    contents = contents + msg[i];
                }
            }

            Console.WriteLine("[{0}] >> {1}", address, contents);
        }


    }
}
