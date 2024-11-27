using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main method Started");
            SomeMethod();
            Console.WriteLine("Main method End");
            Console.ReadKey();
        }
        public async static void SomeMethod()
        {
            Console.WriteLine("Some Method Started");
            //Thread.Sleep(TimeSpan.FromSeconds(10));
            //await Task.Delay(TimeSpan.FromSeconds(10));
            //Console.WriteLine("\n");
            await Wait();
            Console.WriteLine("Some Method Ended");
        }
        public static async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("\n 10 Seconds wait Completed\n");
        }
    }
}
