using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryWriterReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open("C:\\Users\\SumedhNaidu\\source\\repos\\DotNetClass\\BinaryWriter.bin", FileMode.Create)))
            {
                bw.Write("0x80234400");
                bw.Write("Windows Explorer Has Stopped Working");
                bw.Write(true);
            }
            Console.WriteLine("Binary File Created");
            Console.ReadKey();
        }
    }
}
