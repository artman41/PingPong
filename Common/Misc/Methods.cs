using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.Misc {
    public static class Methods {

        public static ConsoleColor GetColour(Color c) {
            if (c == Color.Black) {
                return ConsoleColor.Black;
            }
            if (c == Color.Blue) {
                return ConsoleColor.Blue;
            }
            if (c == Color.Cyan) {
                return ConsoleColor.Cyan;
            }
            if (c == Color.DarkBlue) {
                return ConsoleColor.DarkBlue;
            }
            if (c == Color.DarkCyan) {
                return ConsoleColor.DarkCyan;
            }
            if (c == Color.DarkGray) {
                return ConsoleColor.DarkGray;
            }
            if (c == Color.DarkGreen) {
                return ConsoleColor.DarkGreen;
            }
            if (c == Color.DarkMagenta) {
                return ConsoleColor.DarkMagenta;
            }
            if (c == Color.DarkRed) {
                return ConsoleColor.DarkRed;
            }
            if (c == Color.Gray) {
                return ConsoleColor.Gray;
            }
            if (c == Color.Green) {
                return ConsoleColor.Green;
            }
            if (c == Color.Magenta) {
                return ConsoleColor.Magenta;
            }
            if (c == Color.Red) {
                return ConsoleColor.Red;
            }
            if (c == Color.White) {
                return ConsoleColor.White;
            }
            if (c == Color.Yellow) {
                return ConsoleColor.Yellow;
            } else {
                return ConsoleColor.White;
            }
        }

        public static void Debug(Exception e) {
            Console.WriteLine("DEBUG : " + e.Message + e.StackTrace);
        }

        public static void Debug(Object e) {
            Console.WriteLine("DEBUG : " + e);
        }

        public static void Debug(String e) {
            Console.WriteLine("DEBUG : " + e);
        }

        public static void Debug(String[] e) {
            for (int i = 0; i < e.Length; i++) {
                Console.WriteLine("DEBUG : " + e[i]);
            }
        }

        public static void WriteArray(String[] x) {
            for(int i=0; i < x.Length; i++) {
                Console.WriteLine(x[i]);
            }
        }

        public static void WriteArray(String prefix, String[] x) {
            for (int i = 0; i < x.Length; i++) {
                Console.WriteLine(prefix + x[i]);
            }
        }

        public static IPAddress LocalIPAddress() {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

    }
}
