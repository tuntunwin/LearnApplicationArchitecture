// See https://aka.ms/new-console-template for more information
using NSupport;

namespace ConsoleApp1 {

    public class Program
    {
        delegate void Print(string message);

        static void MyPrint1(string message) {
            Console.WriteLine("Print 1 " + message);
        }

        static void MyPrint2(string message)
        {
            Console.WriteLine("Print 2 " + message);
        }
        static void Main(string[] args)
        {
            //var printFunction1 = new Print(MyPrint1);

            //var printFunction2 = new Print(MyPrint2);
            //var combinePrint = (Print)Delegate.Combine(printFunction1, printFunction2);

            //combinePrint("Hello World");
            //long eightKB = (1024L * 8);
            //long eightMB = (1024L * 1024  * 8);
            //long eightGB = (1024L * 1024 * 1024 * 8);
            //Console.WriteLine(1.Kilobyte().Megabytes());
            //Console.WriteLine(1.Gigabytes());
            //"http://{0}:{1}?name={2}"
            //    .FormatWith("localhost", "80", "Tun Tun Win")
            //    .UrlEncode()
            //    .UrlDecode()
            //    .Dump();

            //var message = String.Format("{0} GB equals to {1}".FormatWith(8, 8.Gigabyte()));
            //Console.WriteLine(String.Format("{0} GB equals to {1}".FormatWith(8, 8.Gigabyte())));
            //Console.Write("{0} GB equals to {1}".FormatWith(8, 8.Gigabyte()));

            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var oddNums = new List<int>();

            //foreach (var n in nums) {
            //    if (n.IsOdd()) {
            //        oddNums.Add(n);
            //    }
            //}

            //foreach (var n in oddNums)
            //{
            //    "method 1 => {0}".FormatWith(n).Dump();
            //}
            //var name = "Andrew S. Tanenbaum - Distributed Systems. Principles and Paradigms.pdf";
            //name.Substring(0, name.LastIndexOf('.')).Dump();
            //Directory.GetFiles(@"D:\books\xxx\ttt")
            //    .Where(f => f.EndsWith(".pdf"))
            //    .Select(f => f.Split('\\')[4])
            //    .Select(f => f.Substring(0, f.LastIndexOf('.')))
            //    .Dump("");

            var files = Directory.GetFiles(@"D:\books");
            var pdfFiles = MyExtensions.Select(MyExtensions.Where(files, f => f.EndsWith(".pdf")), f=> new
            {
                Name = Path.GetFileNameWithoutExtension(f),
                Extension = Path.GetExtension(f)
            });

            // pdfFiles = files.Where(f => f.EndsWith(".pdf"));
            pdfFiles.Dump("");
            //.Where(f => f.EndsWith(".pdf"))
            Directory.GetFiles(@"D:\books")
               .Where(f => f.EndsWith(".pdf"))
               .Select(f => new
               {
                   Name = Path.GetFileNameWithoutExtension(f),
                   Extension = Path.GetExtension(f)
               })
               .Select(x => "File has name=\"{0}\" and extension=\"{1}\"".FormatWith(x.Name, x.Extension))
               .Dump("");

            Enumerable.Range(0, 100).OrderDump("");
            //nums.Dump("");
            //Console.WriteLine("---------");
            //nums
            //    .Where(n => n.IsEven())
            //    .Dump("");
            //Console.WriteLine("---------");
            //nums
            //    .Where(n => n.IsEven())
            //    .Select(n => "Kilo bytes of {0} is {1}".FormatWith(n, n.Kilobyte()))
            //    //.Select(n => n.Kilobyte())
            //    .Dump("");

            //var qry = from n in nums
            //          where n.IsEven()
            //          select "Kilo bytes of {0} is {1}".FormatWith(n, n.Kilobyte());

            //qry.Dump("linq query way:");


        }

    }

}