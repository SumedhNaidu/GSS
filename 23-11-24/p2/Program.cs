using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphorePractice
{
    internal class Program
    {
        //public static Semaphore semaphore = null;
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        semaphore = Semaphore.OpenExisting("SemaphoreDemo");
        //    } catch(Exception Ex)
        //    {
        //        semaphore = new Semaphore(2, 2, "SemaphoreDemo");
        //    }
        //    Console.WriteLine("External Thread Trying to Acquiring");
        //    semaphore.WaitOne();
        //    Console.WriteLine("External thread Acquired");
        //    Console.ReadKey();
        //    semaphore.Release();

        public static Semaphore semaphore = new Semaphore(2, 3);
        public static void Main(String[] args)
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread t = new Thread(DoSomeTask)
                {
                    Name = "Thread " + i
                };
                t.Start();
            }
            Console.ReadKey();
        }
        static void DoSomeTask()
        {
            Console.WriteLine(Thread.CurrentThread.Name + "Wants to Enter Critical Section");
            try
            {
                semaphore.WaitOne();
                Console.WriteLine("Success " + Thread.CurrentThread.Name + " is Doing it's Work");
                Thread.Sleep(5000);
                Console.WriteLine(Thread.CurrentThread.Name + " Exit.");
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}

