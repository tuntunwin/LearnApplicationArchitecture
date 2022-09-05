using BankingConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BankingConsoleApp
{
    static class MyExtensions
    {
        public static int Increase(this int a)
        {
            return a + 1;
        }
        public static int Decrease(this int a)
        {
            return a - 1;
        }
        public static DateTime Tomorrow(this DateTime d)
        {
            return d.AddDays(1).Date;
        }
        public static DateTime Yesterday(this DateTime d)
        {
            return d.AddDays(-1).Date;
        }
        public static DateTime After(this DateTime d, int days)
        {
            return d.AddDays(days).Date;
        }

        public static DateTime Before(this DateTime d, int days)
        {
            return d.AddDays(-days).Date;
        }

        public static Account SearchByAccNo(this List<Account> accounts, string accNo)
        {
            foreach (var acc in accounts)
            {
                if (acc.AccNo == accNo)
                    return acc;
            }
            return null;
        }

        public static void Dump(this object obj) { 
            Console.WriteLine(obj.ToString());
        }

        public static bool IsEven(this int num)
        {
            if(num % 2 == 0) 
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsOdd(this int num)
        {
            if (num % 2 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static decimal Round(this double num)
        {
            return Convert.ToDecimal(Math.Round(num));
        }

        public static int WordCount(string text)
        {
            int space_count=1;
            foreach (char av in text)
            {
                if (av.ToString() == " ")
                {
                    space_count = space_count + 1;
                }               
            }
            return space_count;
        }

    }
}
