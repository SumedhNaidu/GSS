using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            FileStream f1 = new FileStream(str, FileMode.Create);
            //f.Write("Diff between relative and Absolute Path");
            f1.Close();
            Console.WriteLine("File Created");

            string FilePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            FileStream f = new FileStream(FilePath, FileMode.Append);
            byte[] b = Encoding.Default.GetBytes("C# Is an Object Oriented Programming Language");
            f.Write(b, 0, b.Length);
            f.Close();
            Console.WriteLine("Successfully saved file with data");

            string filePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            string data;
            FileStream fRead = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fRead))
            {
                data = sr.ReadToEnd();
            }

                Console.ReadKey();
        }
    }
}
