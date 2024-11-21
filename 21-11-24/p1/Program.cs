using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticeThreads
{
    public class PracticeThread {
		public static void Main(String[] args)
    {
        Console.WriteLine("MainThread Started");
        Thread t1 = new Thread(Method1);
        Thread t2 = new Thread(Method2);
        Thread t3 = new Thread(Method3);
        t1.Start();
        t2.Start();
        t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();
            //t2.Join(TimeSpan.FromSeconds(3));
            //t3.Join(3000);

            if (t2.Join(TimeSpan.FromSeconds(3)))
            {
                Console.WriteLine("Thread 2 Execution Completed");
            }
            else
            {
                Console.WriteLine("Thread 2 Execution Not Completed");
            }
            if (t3.Join(3000))
            {
                Console.WriteLine("Thread 3 Execution Completed");
            }
            else
            {
                Console.WriteLine("Thread 3 Execution Not Completed");

            }
            Console.WriteLine("MainThread Ended");
            Console.ReadKey();
    }
    public static void Method1()
    {
        Console.WriteLine("Method1 Started");
        Thread.Sleep(3000);
        Console.WriteLine("Method1 Ended");
    }
    public static void Method2()
    {
        Console.WriteLine("Method2 Started");
        Thread.Sleep(2000);
        Console.WriteLine("Method2 Ended");
    }
    public static void Method3()
    {
        Console.WriteLine("Method3 Started");
        Thread.Sleep(5000);
        Console.WriteLine("Method3 Ended");
    }
}
}
