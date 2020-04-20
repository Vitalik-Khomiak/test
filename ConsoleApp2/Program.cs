using System;
class Program
{
    static void Main()
    {
        int d;
        Console.WriteLine("Запиши значення d ");
        d = Convert.ToInt32(Console.ReadLine());
        
        switch (d)
        {
            case int n when (d == 12 || d ==1 || d ==2):
                Console.WriteLine("Winter");
                break;
            case int n when (d == 3 || d ==4 || d ==5):
                Console.WriteLine("Spring");
                break;
            case int n when (d == 6 || d == 7 || d == 8):
                Console.WriteLine("Summer");
                break;
            case int n when (d == 9 || d == 10 || d == 11):
                Console.WriteLine("Autumn");
                break;
            default:
                Console.WriteLine("Enter a different value");
                break;

                
        }

        Console.ReadLine();
    }
    
}