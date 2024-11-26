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
            //string str = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            //FileStream f1 = new FileStream(str, FileMode.Create);
            ////f.Write("Diff between relative and Absolute Path");
            //f1.Close();
            //Console.WriteLine("File Created");

            //string FilePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            //FileStream f = new FileStream(FilePath, FileMode.Append);
            //byte[] b = Encoding.Default.GetBytes("C# Is an Object Oriented Programming Language");
            //f.Write(b, 0, b.Length);
            //f.Close();
            //Console.WriteLine("Successfully saved file with data");

            //string filePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            //string data;
            //FileStream fRead = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //using (StreamReader sr = new StreamReader(fRead))
            //{
            //    data = sr.ReadToEnd();
            //}

            //StreamWriter sw = new StreamWriter("C:\\Users\\SumedhNaidu\\source\\repos\\DotNetClass\\Task.txt");

            //Console.WriteLine("Enter text");
            //string input = Console.ReadLine();
            //sw.Write(input);
            //Console.WriteLine("Text inserted succesfully");
            //sw.Flush();
            //sw.Close();

            //string FilePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            //int a = 10;
            //int b = 20;
            //int res = a + b;
            //using (StreamWriter sw = new StreamWriter(FilePath, true))
            //{
            //    sw.Write($"Sum of {a} + {b} = {res}");
            //}
            //Console.WriteLine("Variable data is saved");

            //string filePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            //StreamReader sw = new StreamReader(filePath);
            //Console.WriteLine("Content of the File");
            ////sw.BaseStream.Seek(0, SeekOrigin.Begin);
            //string strData = sw.ReadLine();
            //while (strData != null)
            //{
            //    Console.WriteLine(strData);
            //    strData = sw.ReadLine();
            //}
            //Console.ReadLine();
            //sw.Close();

            //string filePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            //StreamReader sw = new StreamReader(filePath);
            //Console.WriteLine("Content of the File");
            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    Console.WriteLine(sr.ReadToEnd());
            //}

            string filePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\Task.txt";
            using(StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Welcome to .Net Tutorials");
                sw.WriteLine("Currently Learning FileHandling");
            }
            Console.WriteLine("\n Reading Approach 1 : using ReadToEnd Method");
            using (StreamReader sr = new StreamReader(filePath))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            Console.WriteLine("\n Reading Approach 2: Using ReadLine Method");
            StreamReader sr1 = new StreamReader(filePath);
            string strData = sr1.ReadLine();
            while(strData != null)
            {
                Console.WriteLine(strData);
                strData = sr1.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
