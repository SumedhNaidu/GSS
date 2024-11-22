using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOnStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Good morning. Have a nice day";
            string word = "nice day";
            string empty = "";
            //str.Substring();
            //Console.WriteLine(w1);
            //for (int i = 0; i < str.Length; i++)
            //{
            //    string w1 = str.Substring(i, word.Length);
            //    if (word == w1)
            //    {
            //        Console.WriteLine(w1);
            //        break;
            //    }

            //}

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'n')
                {
                    for (int j = i; j < i + word.Length; j++)
                    {
                        empty += str[j];
                    }
                    //Console.WriteLine(empty);
                    if (empty == word)
                    {
                        Console.WriteLine(empty);
                        break;
                    }
                    else
                    {
                        empty = "";
                        //Console.WriteLine("Not Found");
                    }
                }
            }

            string str1 = "Good Morning Alexa";
            string oldWord = "Morning";
            string newWord = "Afternoon";
            String empty1 = "";
            StringBuilder sb = new StringBuilder(str1);
            //sb.Replace(oldWord, newWord);
            //Console.WriteLine(sb);

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == 'M' || str1[i] == 'm' && str[i + 1] == 'o')
                {
                    for (int j = i; j < i + oldWord.Length; j++)
                    {
                        empty1 += str[j];
                    }
                    Console.WriteLine(empty1);
                    int index = 0;
                    if (empty1.ToLower() == oldWord.ToLower())
                    {
                        sb.Remove(i, oldWord.Length);
                        sb.Insert(i, newWord);
                        index++;
                        Console.WriteLine(sb);
                        break;
                    }
                    else
                    {
                        index = 0;
                        Console.WriteLine("no");
                    }
                }
            }
            Console.WriteLine(sb);

        }
    }
}
