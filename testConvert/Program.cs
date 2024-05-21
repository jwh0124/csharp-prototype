// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

byte[] xStationNewByte = [
    51, 49, 51, 55, 51, 52, 51, 49, 51, 48, 
    51, 52, 51, 57, 51, 57, 51, 48, 51, 51,
    51, 56, 51, 51, 51, 54,  0,  0,  0,  0, 
    0, 0 ];

string testCode = string.Empty;

xStationNewByte.ToList().ForEach(a => testCode += (Convert.ToChar(a)));

Console.WriteLine(testCode);

Console.ReadLine();
