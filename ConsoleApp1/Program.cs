using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace ConsoleApp1
{
    class Program
    {  
        static void Main(string[] args)
        {
            string d;
            using (StreamReader f = new StreamReader("input.txt")) {d = f.ReadToEnd(); }
            Console.WriteLine(d);
            d = d.Trim();
            string x =(Regex.Replace(d, "[ ]+", " ")); //переписаний
            Console.WriteLine(x);
            using (StreamWriter f = new StreamWriter("output.txt", true))
            {
                f.Write(x);
            }
            }
        }
}
