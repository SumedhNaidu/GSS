using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexPractice
{
    class Program
    {
        private static Mutex mutex = new Mutex();
        static void Main(String[] args)
        {
            for (int i = 0; i <= 5; i++)
            {
                Thread threadObj = new Thread(MutexDemo)
                {
                    Name = "Thread " + i
                };
                threadObj.Start();
            }
            Console.ReadKey();
        }
        static void MutexDemo()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to enter critical section for processing");
            if (mutex.WaitOne(1000))
            {
                try
                {
                    Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
                    Thread.Sleep(2000);
                    Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " Completed its task");
                }
                finally
                {
                    mutex.ReleaseMutex();
                    Console.WriteLine(Thread.CurrentThread.Name + " has released the mutex");
                }
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " will not acquire the mutex");
            }
        }
        ~Program()
        {
            mutex.Dispose();
        }
    }
}
