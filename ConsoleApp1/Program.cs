using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Menu_Data
    {
        public string name { get; set; }
        public string price { get; set; }
        public string cooking_time { get; set; }
        public string gram { get; set; }
        public string kitchen { get; set; }
    }
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void menuData()
        {
            while (true)
            {
                try
                {               
                    Console.WriteLine("   Hot key   │            Function       ");                  
                    Console.WriteLine("      A      │       Add new student  ");                   
                    Console.WriteLine("      S      │ Search student by city  ");                  
                    Console.WriteLine("      D      │ Delete student by city ");                  
                    Console.WriteLine("      T      │      Show all students base  ");                    
                    Console.WriteLine("    Space    │         Clear console  ");                   
                    Console.WriteLine("     Esc     │          Exit program  ");                   
                    var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));//конвертація                           
                    var y = Console.ReadKey();
                    var x = y.Key;
                    switch (x)
                    {
                        case ConsoleKey.A:                                                                //  Add new student
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Menu Data\n");
                                Console.WriteLine("Name: ");
                                string Name = Console.ReadLine();
                                Console.WriteLine("price: ");
                                string Price = Console.ReadLine();
                                Console.WriteLine("cooking_time: ");
                                string Cooking_time = Console.ReadLine();
                                Console.WriteLine("gram: ");
                                string Gram = Console.ReadLine();
                                Console.WriteLine("kitchen: ");
                                string Kitchen = Console.ReadLine();
                                if (Name != null && Price != null && Cooking_time != null && Gram != null && Kitchen != null)
                                {
                                    data.Add(new Menu_Data { name = Name, price = Price, cooking_time = Cooking_time, gram = Gram, kitchen = Kitchen });
                                }
                                else
                                {
                                    Console.WriteLine("Будь ласка, заповніть всі поля");
                                }
                                Console.Clear();
                                break;
                            }
                         case ConsoleKey.S:                                                             //Search student by city
                            {
                                Console.Clear();
                                Console.WriteLine("Enter search name: ");
                                string nam = Console.ReadLine();
                                if (Console.ReadLine() != null)
                                {
                                    Console.Clear();
                                    Menu_Data FoundData = data.Find(found => found.name == nam);
                                    if (FoundData != null)
                                    {
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                        Console.Write("\t" + FoundData.name + "\t");
                                        Console.Write("\t\t " + FoundData.price + "\t");
                                        Console.Write("\t\t " + FoundData.cooking_time + "\t");
                                        Console.Write("\t\t\t" + FoundData.gram + "\t");
                                        Console.Write("\t" + FoundData.kitchen + "\t\n");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                        Console.WriteLine("\nTo edit press 'E'");
                                        Console.WriteLine("\n\nTo edit press 'D'");

                                        if (Console.ReadKey().Key == ConsoleKey.E)
                                        {
                                            Console.WriteLine("\nEdit Student Data\n");
                                            Console.WriteLine("Name: ");
                                            string Name = Console.ReadLine();
                                            Console.WriteLine("price: ");
                                            string Price = Console.ReadLine();
                                            Console.WriteLine("cooking_time: ");
                                            string Cooking_time = Console.ReadLine();
                                            Console.WriteLine("gram: ");
                                            string Gram = Console.ReadLine();
                                            Console.WriteLine("kitchen: ");
                                            string Kitchen = Console.ReadLine();
                                            if (Name != null && Price != null && Cooking_time != null && Gram != null && Kitchen != null)
                                            {
                                                Console.WriteLine("Будь ласка, заповніть всі поля");
                                            }
                                            FoundData.name = Name;
                                            FoundData.price = Price;
                                            FoundData.cooking_time = Cooking_time;
                                            FoundData.gram = Gram;
                                            FoundData.kitchen = Kitchen;
                                            Console.Clear();
                                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                            Console.Write("\t" + FoundData.name + "\t");
                                            Console.Write("\t\t " + FoundData.price + "\t");
                                            Console.Write("\t\t " + FoundData.cooking_time + "\t");
                                            Console.Write("\t\t\t" + FoundData.gram + "\t");
                                            Console.Write("\t" + FoundData.kitchen + "\t\n");
                                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                        }                 // РЕДАГУВАННЯ
                                        if (Console.ReadKey().Key == ConsoleKey.D)                     // Видалення
                                        {
                                            data.RemoveAll(x => x.name == nam);
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Error\n\n" +
                                    "Student not found");
                                    }
                                }
                                break;
                            }
                        case ConsoleKey.T:                                                               //Show all students base
                            {
                                Console.Clear();

                                Console.WriteLine("\tName\t\t│  \tPrice\t\t│  Cooking_time\t\t│\t\tGram\t│\tKitchen\t");

                                for (int i = 0; i < data.Count; i++)
                                {
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                    Console.Write("\t" + data[i].name + "\t");
                                    Console.Write("\t\t " + data[i].price + "\t");
                                    Console.Write("\t\t " + data[i].cooking_time + "\t");
                                    Console.Write("\t\t\t" + data[i].gram + "\t");
                                    Console.Write("\t" + data[i].kitchen + "\t\n");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                }
                               
                                Console.WriteLine("\nTo sort by gram press 'G'"); //сортування 
                                Console.WriteLine("\nTo sort by name press 'N'");
                                Console.WriteLine("\nTo sort by kitchen press 'K'");
                                if (Console.ReadKey().Key == ConsoleKey.G)
                                {
                                    Console.Clear();
                                    List<Menu_Data> SortData = data.OrderBy(o => o.gram).ToList();
                                    Console.WriteLine("\tName\t\t│  \tPrice\t\t│  Cooking_time\t\t│\t\tGram\t│\tKitchen\t");

                                    for (int i = 0; i < data.Count; i++)
                                    {
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                        Console.Write("\t" + SortData[i].name + "\t");
                                        Console.Write("\t\t " + SortData[i].price + "\t");
                                        Console.Write("\t\t " + SortData[i].cooking_time + "\t");
                                        Console.Write("\t\t\t" + SortData[i].gram + "\t");
                                        Console.Write("\t" + SortData[i].kitchen + "\t\n");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                    }
                                
                                }
                                if (Console.ReadKey().Key == ConsoleKey.N)
                                {
                                    Console.Clear();
                                    List<Menu_Data> SortData = data.OrderBy(o => o.name).ToList();

                                    Console.WriteLine("\tName\t\t│  \tPrice\t\t│  Cooking_time\t\t│\t\tGram\t│\tKitchen\t");

                                    for (int i = 0; i < data.Count; i++)
                                    {
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                        Console.Write("\t" + SortData[i].name + "\t");
                                        Console.Write("\t\t " + SortData[i].price + "\t");
                                        Console.Write("\t\t " + SortData[i].cooking_time + "\t");
                                        Console.Write("\t\t\t" + SortData[i].gram + "\t");
                                        Console.Write("\t" + SortData[i].kitchen + "\t\n");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                    }                       
                                }
                                if (Console.ReadKey().Key == ConsoleKey.K)
                                {

                                    Console.Clear();
                                    List<Menu_Data> SortData = data.OrderBy(o => o.kitchen).ToList();

                                    Console.WriteLine("\tName\t\t│  \tPrice\t\t│  Cooking_time\t\t│\t\tGram\t│\tKitchen\t");

                                    for (int i = 0; i < data.Count; i++)
                                    {
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                        Console.Write("\t" + SortData[i].name + "\t");
                                        Console.Write("\t\t " + SortData[i].price + "\t");
                                        Console.Write("\t\t " + SortData[i].cooking_time + "\t");
                                        Console.Write("\t\t\t" + SortData[i].gram + "\t");
                                        Console.Write("\t" + SortData[i].kitchen + "\t\n");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                    }
                                  
                                }
                                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                                {
                                    Console.Clear();
                                }
                                break;
                            }
                        case ConsoleKey.Escape:                                                           //Exit program
                            {
                                Environment.Exit(0);
                                break;
                            }
                        case ConsoleKey.D:                                                                  //Delete student by city
                            {
                                Console.Clear();
                                Console.WriteLine("Enter name to delete: ");
                                string Name = Console.ReadLine();
                                if (Console.ReadLine() != null)
                                {
                                    Console.Clear();
                                    Menu_Data FoundData = data.Find(found => found.name == Name);
                                    if (FoundData != null)
                                    {
                                        Console.WriteLine("\tName\t│  Price\t│  Cooking_time\t│\t\tGram\t\t│\tKitchen\t");

                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                        Console.Write("\t" + FoundData.name + "\t");
                                        Console.Write("\t\t " + FoundData.price + "\t");
                                        Console.Write("\t\t " + FoundData.cooking_time + "\t");
                                        Console.Write("\t\t\t" + FoundData.gram + "\t");
                                        Console.Write("\t" + FoundData.kitchen + "\t\n");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                        data.RemoveAll(x => x.name == Name);
                                        Console.WriteLine("This information has been deleted");
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Error\n\n" +
                                    "City not found");
                                    }
                                }
                                break;
                            }
                        case ConsoleKey.Spacebar:                                                            //Clear console
                            {
                                Console.Clear();
                                break;
                            }                        
                    }
                    string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                    if (serialize.Count() > 1)
                    {
                        if (!File.Exists(FileName))
                        {
                            File.Create(FileName).Close();
                        }
                        File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }
        static void Main(string[] args)
        {
            menuData();
        }
    } 
}
