using System;

namespace DateCompareConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDt = DateTime.Parse("2020-06-17T07:30:44.577");

            DateTime endDt = DateTime.Parse("2020-06-16T07:30:44.577");

            DateTime currentDate = DateTime.Now;

            Console.WriteLine(DateTime.Compare(currentDate, startDt) >= 0);
            Console.WriteLine(DateTime.Compare(currentDate, endDt) <= 0);
            Console.WriteLine(!(DateTime.Compare(currentDate, startDt) >= 0 && DateTime.Compare(currentDate, endDt) <= 0));
        }
    }
}
