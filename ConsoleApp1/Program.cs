using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = -90;
            Console.WriteLine($"| x  \t||    f(x) \t\t\t|");
            do
            {

                double y = Math.Pow(x, 2) * Math.Cos(x);


                Console.WriteLine($"|{x}  \t||    {y} \t|");
                x += -18;

            } while ( x >= -270 && x <= -90 );

        }
    }
}
