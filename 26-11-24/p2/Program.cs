using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReaderWriter
{
    public class Program
    {
        static void Main(String[] args)
        {
            //string text = "This is First Line \nThis is Second Line \n This is Third Line";
            //StringBuilder sb = new StringBuilder();
            //StringWriter sw = new StringWriter(sb);

            //sw.WriteLine(text);
            //sw.Flush();
            //sw.Close();

            //StringReader sr = new StringReader(sb.ToString());
            //while (sr.Peek() > -1)
            //{
            //    Console.WriteLine(sr.ReadLine());
            //}

            string text = @"You are reading this StringWriter and StringReader in C# article at dotnettutorials.net";
            using(StringReader sr = new StringReader(text))
            {
                int count = 0;
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    count++;
                    Console.WriteLine("Line {0}: {1}",count,line);
                }
            }
            Console.ReadKey();
        }
    }
}
