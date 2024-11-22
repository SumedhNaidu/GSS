using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    class Program
    {
        static (int, string, bool) GetMultipleValues()
        {
            return (42, "Hello", true);
        }
        static void Main()
        {
            var quote="";
            var result = GetMultipleValues();
            Console.WriteLine($"Number:{result.Item1}, Text:\"{result.Item2}\", Flag:{result.Item3}");    
        }
    }
}
