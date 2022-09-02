using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSupport;

namespace ConsoleApp1
{
    static internal class MyExtensions
    {
        public static void Dump(this string source) {
            Console.WriteLine(source);
        }

        public static void Dump(this int source)
        {
            Console.WriteLine(source);
        }

        public static void Dump(this IEnumerable<string> source, string tag)
        {
            foreach (var item in source)
            {
                "{0} {1}".FormatWith(tag,item).Dump();
            }

        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    Console.WriteLine("My Where");
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
            foreach (var item in source)
            {
                Console.WriteLine("My Select");
                yield return selector(item);
            }
        }
    }
}
