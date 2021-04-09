using RestSharp;
using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace RFCardPrototype
{
    class Program
    {
        static SerialPort _serialPort = new SerialPort();
        static bool _continue;
        static int exceptionCount;
        static int taggingCount;
        
        public static void Main(string[] args)
        {
            _serialPort.PortName = "/dev/ttySAC3";
            _serialPort.BaudRate = 9600;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.WriteTimeout = 100;
            _serialPort.ReadTimeout = 100;
            _serialPort.Handshake = Handshake.None;

            try
            {
                _serialPort.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine("Serial port open Error : " + e.Message);
            }
            _continue = true;

            Thread.Sleep(300);
            Send();

            while (_continue)
            {
                if (Read().Result > 0 || exceptionCount > 10)
                {
                    Send();
                    exceptionCount = 0;
                };
            }
        }

        public async static Task<int> Read()
        {
            try
            {
                byte[] data = new byte[11];
                int bytesRead = _serialPort.Read(data, 0, data.Length);
                
                if(bytesRead > 0)
                {
                    try
                    {
                        if (bytesRead > 6)
                        {
                            string[] sendPacket = BitConverter.ToString(data).Split('-');
                            string cardNo = String.Empty;
                            for (int i = 5; i < 9; i++)
                            {
                                cardNo += sendPacket[i];
                            }

                            await restClientPut(cardNo);
                            taggingCount += 1;
                            Console.WriteLine("Card tagging count : " + taggingCount);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Thread.Sleep(100);
                    return bytesRead;
                }
                return 0;
            }
            catch (TimeoutException)
            {
                exceptionCount += 1;
                if(exceptionCount > 5)
                {
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss") + " Exception Count :" + exceptionCount);
                }
                return 0;
            }
        }

        public static void Send()
        {
            byte[] bytetosend = new byte[] { 0x02, 0x00, 0x02, 0x01, 0x01, 0x03 };

            try
            {
                _serialPort.Write(bytetosend, 0, bytetosend.Length);
            }
            catch (TimeoutException e)
            {
                Console.WriteLine("SerialPort Send Exception: " + e.Message);
            }
        }

        public static async Task<IRestResponse> restClientPut(string cardNo)
        {
            IRestClient client = new RestClient("http://localhost:5000/");
            IRestRequest request = new RestRequest(string.Format("auth/card/{0}",cardNo), Method.PUT);

            return await client.ExecuteAsync(request);
        }
    }
}
