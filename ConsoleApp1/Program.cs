using System;

namespace ConsoleApp1
{
   public class Program
    {

        

        
        public static void test(int[,]c)
        {
            int max = c[1, 1];
            int max_i = 0;

            int suma = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (max < c[i, j])
                    {
                        max_i = i;
                        max = c[i, j];

                    }

                }

            }

            Console.WriteLine("Max = " + max);
            Console.WriteLine("Max_i = " + max_i);
            for (int i = 0; i < 3; i++)
            {

                suma += c[i, i];

            }
            Console.WriteLine("Suma = " + suma);


            for (int i = 0; i < 3; i++) ;
            {
                for (int j = 0; j < 3; j++)
                {
                    c[max_i, j] = suma;
                }

            }


            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {

                    Console.Write(c[i, j] + " ");
                }
                Console.WriteLine();
            }



        }



        public static void Main()
        {



            int N = 3;
            int[,] c = new int[N, N];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    Console.Write($"Data[{j}]=");
                    c[i, j] = Convert.ToInt32(Console.ReadLine());
                }

            }
            test(c);
        }
    }
}

        
            



