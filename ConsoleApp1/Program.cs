using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str1;
            string str;
            List <int> b = new List <int>();

            Console.WriteLine("Введiть речення");
            str = Console.ReadLine();
            str = str.Trim();
            Console.WriteLine(Regex.Replace(str, "[ ]+", " "));


            string[] split = str.Split(new Char[] { ' ',',','.' }) ;





            for (int j = 0; j < split.Length; j++)
                {
                b.Add(0);
                str1 = split[j].ToCharArray();
                for(int i=0;i<str1.Length;i++)
                {
                    if ((str1[i] == 'а')|| (str1[i] == 'о')|| (str1[i] == 'у')|| (str1[i] == 'е')|| (str1[i] == 'и')|| (str1[i] == 'i'))
                    {
                        
                        b[j] += 1;
                    }

                }
               


                }

                foreach(int s in b){
               
                Console.WriteLine(s);

            }
            

        }
    }
}
