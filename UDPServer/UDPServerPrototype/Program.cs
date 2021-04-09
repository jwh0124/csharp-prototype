using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPServerPrototype
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region UDP Server
            //int recv;
            //byte[] data = new byte[1024];
            //IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            //Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //newsock.Bind(ipep);
            //Console.WriteLine("Waiting for a Client...");

            //IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            //EndPoint remote = (EndPoint)sender;

            //recv = newsock.ReceiveFrom(data, ref remote);

            //Console.WriteLine("Message received from {0} :", remote.ToString());
            //Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            //string welcome = "Welcome to my test server";
            //data = Encoding.ASCII.GetBytes(welcome);
            //newsock.SendTo(data, data.Length, SocketFlags.None, remote);
            //while (true)
            //{
            //    data = new byte[1024];
            //    recv = newsock.ReceiveFrom(data, ref remote);

            //    Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            //    newsock.SendTo(data, recv, SocketFlags.None, remote);
            //}
            #endregion

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            socket.Bind(ipep);
            EndPoint ep = (EndPoint)ipep;

            byte[] data = new byte[1024];
            int recv = socket.ReceiveFrom(data, ref ep);
            string[] receiveIPPort = ep.ToString().Split(':');
            string receiveIP = receiveIPPort[0];

            string hostName = Dns.GetHostName();
            string ip = GetIPAddress(hostName);

            byte[] returnData = new byte[1024];
            IPEndPoint returnIpep = new IPEndPoint(IPAddress.Parse(receiveIP), 9060);
            Socket returnSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            returnData = Encoding.ASCII.GetBytes(ip);
            returnSocket.SendTo(returnData, returnIpep);
            returnSocket.Close();
            Console.WriteLine(returnData);
            Console.Read();
        }

        public static string GetIPAddress(string hostname)
        {
            IPHostEntry host = Dns.GetHostEntry(hostname);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
    }
}
