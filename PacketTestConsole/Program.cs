using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PacketTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                string readPacket = Console.ReadLine();
                var resultPacket = string.Empty;
                if (readPacket.Equals("02"))
                {
                    resultPacket += readPacket;

                    Console.ReadLine();

                    int dataLength = int.Parse(Console.ReadLine());

                    for (int i = 0; i < dataLength; i++)
                    {
                        resultPacket += Console.ReadLine();
                    }

                    Console.WriteLine(resultPacket);
                }
            }            

        }
    }
}
