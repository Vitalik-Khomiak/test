using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x_r, y;
            double x;
            Console.Write("x = ");
            double Pi = Math.PI;
            x = double.Parse(Console.ReadLine());

            do
            {

                x_r = (Pi / 180) * x;

                y = Math.Pow(x_r, 2) * Math.Cos(x_r);

                double y_e = Math.Round(y, 4);
                Console.WriteLine($"|{x}  \t||    {y_e} \t|");
                x += -18;

            } while (x >= -270 && x <= -90);
        }
    }
}
