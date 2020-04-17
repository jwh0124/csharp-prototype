using System;

namespace CallbackMethod
{
    class Program
    {
        delegate void CalcDelegate(int x, int y);
        static void Main(string[] args)
        {
            CalcDelegate plus = Plus;

            Callback(20, 10, Plus);
        }

        static void Plus(int x,int y) { Console.WriteLine(x + y); }
        static void Minus(int x, int y) { Console.WriteLine(x - y); }
        static void Multiple(int x, int y) { Console.WriteLine(x * y); }
        static void Divide(int x, int y) { Console.WriteLine(x / y); }

        static void Callback(int x, int y, CalcDelegate dele)
        {
            dele(x, y);
        }
    }
}
