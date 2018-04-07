using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace UDPClientPrototype
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            #region UDP Client
            //byte[] data = new byte[1024];
            //string input, stringData;
            //IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.10.55"), 9050);

            //Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //string welcome = "Hello, are you there";
            //data = Encoding.ASCII.GetBytes(welcome);
            //server.SendTo(data, data.Length, SocketFlags.None, ipep);

            //IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            //EndPoint remote = (EndPoint)sender;

            //data = new byte[1024];
            //int recv = server.ReceiveFrom(data, ref remote);

            //Console.WriteLine("Message received from {0} : ",remote.ToString());
            //Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            //while (true)
            //{
            //    input = Console.ReadLine();
            //    if (input == "exit")
            //        break;
            //    server.SendTo(Encoding.ASCII.GetBytes(input),remote);
            //    data = new byte[1024];
            //    recv = server.ReceiveFrom(data, ref remote);
            //    stringData = Encoding.ASCII.GetString(data, 0, recv);
            //    Console.WriteLine(stringData);
            //}
            //Console.WriteLine("Stopping Client");
            //server.Close();
            #endregion

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipep = new IPEndPoint(IPAddress.Broadcast, 9050);

                string hostname = Dns.GetHostName();
                byte[] data = Encoding.ASCII.GetBytes(hostname);


                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                socket.SendTo(data, ipep);
                socket.Close();

                UdpClient responseClient = new UdpClient();
                IPEndPoint returnIpep = new IPEndPoint(IPAddress.Any, 9060);
                responseClient.Client.ReceiveTimeout = 5000;
                responseClient.ExclusiveAddressUse = false;
                responseClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                responseClient.Client.Bind(returnIpep);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                while (stopWatch.Elapsed < TimeSpan.FromSeconds(5))
                {
                    Console.WriteLine(stopWatch.Elapsed);
                    byte[] test = responseClient.Receive(ref returnIpep);
                    string stringData = Encoding.ASCII.GetString(test);
                    string[] returnIPPort = stringData.ToString().Split(':');
                    string ip = returnIPPort[0];
                    if (ip != null)
                    {
                        Console.WriteLine(ip);
                    }
                }
                
                stopWatch.Stop();
                responseClient.Close();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("finish");
            }
        }
    }
}
