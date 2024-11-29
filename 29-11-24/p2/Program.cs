using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolPractice
{
    class Program
    {
        static void Main(String[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(MyMethod));
            t1.Start(2);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
            }
            Console.ReadKey();
        }
        public static void MyMethod(object obj)
        {
            Thread t = Thread.CurrentThread;
            string message = $"Background: {t.IsBackground}, Thread Pool:{t.IsThreadPoolThread}, Thread ID: {t.ManagedThreadId}";
            Console.WriteLine(message);
        }
    }
}

