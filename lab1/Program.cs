using System;

namespace lab1
{
    public class Program
    {
        static public int summa(int n) 
        {
            int suma = 0;
            while (n != 0)
            {
                suma += n % 10;
                n /= 10;
            }
            Console.WriteLine(suma);
            return suma;


        }
        static public int dob(int n)
        {
            int dob = 1;
            while (n != 0)
            {
                dob += n % 10;
                n /= 10;
            }
            return dob;

        }
        static void Main(string[] args)
        {

            Console.WriteLine("Number = ");
            string S1 = Console.ReadLine();
            int n = int.Parse(S1);
          
            summa(n);
            dob(n);


            Console.ReadLine();
            }
        
    }
}



