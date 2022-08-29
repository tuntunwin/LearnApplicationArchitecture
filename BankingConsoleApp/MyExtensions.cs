using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp
{
    static class MyExtensions
    {
        public static Boolean IsEven(this int i)
        {
            if (i % 2 == 0) { return true; }
            else { return false; }
        }

        public static Boolean IsOdd(this int i)
        {
            if (i % 2 > 0) { return true; }
            else { return false; }
        }

        public static decimal RoundUp(this decimal dec)
        {
           return Math.Round(dec);
        }
    }
}
