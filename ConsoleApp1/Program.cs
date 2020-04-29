using System;

namespace ConsoleApp1
{
    public class Program
    {


        public static void Main()
        {

            Console.WriteLine("ВВедiть розмiр масиву");
            Console.Write("Рядки - ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Стовпцi - ");
            m = Convert.ToInt32(Console.ReadLine());
            if (n == m)
            {





                int[,] c = new int[n, m];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"Data[{i},{j}]=");
                        c[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }



                int max = c[0, 0];
                int max_i = 0;

                int suma = 0;
                for (int i = 0; i < n; i++)
                {

                    for (int j = 0; j < m; j++)
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
                for (int i = 0; i < n; i++)
                {

                    suma += c[i, i];

                }
                Console.WriteLine("Suma = " + suma);


                for (int i = 0; i < 3; i++) ;
                {
                    for (int j = 0; j < m; j++)
                    {
                        c[max_i, j] = suma;
                    }

                }


                for (int i = 0; i < n; i++)
                {

                    for (int j = 0; j < m; j++)
                    {

                        Console.Write(c[i, j] + " ");
                    }
                    Console.WriteLine();
                }



            }
            else
            {
                Console.WriteLine("Некоректний розмiр масиву");
            }


        }
    }
}






