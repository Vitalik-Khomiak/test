using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void ValsGenerator(int[] Vals)
        {
            // Random - клас для генерації випадкових чисел
            Random aRand = new Random();
            // заповнення масиву
            for (int i = 0; i < Vals.Length; i++)
                Vals[i] = aRand.Next(100);
        }
        public static int test1(int[] Data)
        {
            int x = 0;
            
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] < 7)
                {

                    x++;
                }
            }
            Console.WriteLine("Менше 7=" + x);
            return x;
        }



        public static void test2(int[] Data)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                int dob = 1;
                if (Data[i] == 0)
                {
                    int first = i + 1;
                    for (int j = first; j < Data.Length; j++)
                    {
                        if (Data[j] == 0)
                        {
                            int second = j;
                            for (int g = first; g < second; g++)
                            {
                                dob *= Data[g];
                            }
                            Console.WriteLine("dob ="+dob);
                            
                            break;
                        }
                        else
                        {
                           
                        }
                    }
                    break;
                }
                else
                {
                    
                }
            }
           
        }



        public static void test3(int[]data)
        {

            int x = 0;
            const int N = 10;
            int[] Data_a = new int[N];



            ValsGenerator(Data_a);
            Array.Sort(Data_a);
            Console.WriteLine("Друк вiдсортованих даних");
            for (int i = 0; i < Data_a.Length; i++)
            {
                Console.WriteLine("Data[" + i + "] = " + Data_a[i]);
            }
            for (int i = 0; i < 8; i++)
            {
                if (Data_a[i] < 7)
                {
                    x++;
                }
            }
            Console.WriteLine("менше 7 =" + x);
            Console.ReadLine();

        }



        public static void Main()
        {

            Console.WriteLine("Виберіть метод 1- вручну 0 - рандом");
            int c = Convert.ToInt32(Console.ReadLine());
            int N = 4;
            int[] Data = new int[N];
            for (int j = 0; j < Data.Length; j++)
            {
                Console.Write($"Data[{j}]=");
                Data[j] = Convert.ToInt32(Console.ReadLine());
            }
            
            if (c == 1)
            {
                test1(Data);
                test2(Data);
            }

            else
            {
                test3(Data);
            }
            
        }
    }

}