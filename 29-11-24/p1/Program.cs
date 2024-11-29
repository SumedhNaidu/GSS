using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Synchronization
{
    internal class Program
    {
        object lockObj = new object();
        static void Main(string[] args)
        {
            Program p = new Program();
            Thread t1 = new Thread(p.SomeMethod)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(p.SomeMethod)
            {
                Name = "Thread 2"
            };
            Thread t3 = new Thread(p.SomeMethod)
            {
                Name = "Thread 3"
            };
            t1.Start();
            t2.Start();
            t3.Start();

            Console.ReadKey();
        }
        void SomeMethod()
        {

            lock (lockObj)
            {
                Console.Write("Welcome to the ");
                Thread.Sleep(1000);
                Console.WriteLine("world of Dotnet");
            }
           
        }
    }
}
