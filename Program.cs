using System;
using System.IO; // 1
namespace ConsoleApplication1
{
    class Class1
    {
        static int s1;
        static int s2;
        static int s3;

        static void Main()
        {
            StreamWriter f = new StreamWriter("MyFile.txt"); // 2                    
            s1 = 5;
            s2 = 7;
            s3 = 9;

            f.Write(s1 + " "); // 4
            f.Write(s2 + " ");
            f.Write(s3);
            f.Close();
            main2();
        }
        static void main2()
        {
            string d;
            int a, b, c;
            using (StreamReader f = new StreamReader("MyFile.txt")) { d = f.ReadToEnd(); }



            string[] words = d.Split(' ');
            a = Int32.Parse(words[0]);
            b = Int32.Parse(words[1]);
            c = Int32.Parse(words[2]);

            using (StreamWriter f = new StreamWriter("MyFile.txt", true))
            {
               

                if (a + b > c && a + c > b && b + c > a)
                {
                    Console.WriteLine("ТРИКУТНИК");

                    f.WriteLine("\nТрикутник");

                }
                else
                {
                    Console.WriteLine("не ТРИКУТНИК");

                    f.WriteLine("\nнеТрикутник");
                }

            }
        }
    }
}

