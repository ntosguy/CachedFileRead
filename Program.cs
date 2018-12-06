using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string file in Directory.GetFiles(@"C:\Files"))
            {
                Extensions.CachedFileRead(file);
            }

            Console.WriteLine("Running cache reader in 3 seconds again ...");

            Thread.Sleep(3000);

            foreach (string file in Directory.GetFiles(@"C:\Files"))
            {
                Extensions.CachedFileRead(file);
            }

            Console.WriteLine("Running cache in 10 seconds again ...");

            Thread.Sleep(10000);

            foreach (string file in Directory.GetFiles(@"C:\Files"))
            {
                Extensions.CachedFileRead(file);
            }

            Console.WriteLine("Done");

            Console.Read();
        }
    }
}
