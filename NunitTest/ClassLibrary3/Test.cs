using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NunitTest;


namespace NunitTestCode
{
    [TestFixture]
    public class Test
    {
        [TestCase(1, 2, ExpectedResult = 3)]
        public int Sum(int a, int b)
        {
            return Program.Sum(a, b);
        }

        [TestCase(2, 1, ExpectedResult = 1)]
        public int Sub(int a, int b)
        {
            return Program.Sub(a, b);
        }
    }
}
