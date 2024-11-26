using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter_Reader
{
    public class Program
    {
        public static void Main(String[] args)
        {
            string filePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass\TextWriter.txt";
            using (TextWriter tw = File.CreateText(filePath))
            {
                tw.WriteLine("TextWriter Abstract Class");
                tw.WriteLine("Writing with TextWriter:");
            }

            WriteCharAsync();

            Console.ReadKey();
        }
        public static async void WriteCharAsync()
        {
            string FilePath = @"C:\Users\SumedhNaidu\source\repos\DotNetClass";
            using (TextWriter tw = File.CreateText(FilePath))
            {
                await tw.WriteLineAsync("Hello TextWriter Abstract Class");
                await tw.WriteLineAsync("File Handling Tutorial");
            }
            Console.WriteLine("Async Write ");
        }
    }
}
