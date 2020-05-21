
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class House_data
    {
        private string surname;
        private string housenumber;
        private string flatnumber;
        private string sex;
        private string suma;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Housenumber
        {
            get { return housenumber; }
            set { housenumber = value; }
        }
        public string Flatnumber
        {
            get { return flatnumber; }
            set { flatnumber = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Suma
        {
            get { return suma; }
            set { suma = value; }
        }
    }

    class Program
    {

        private static string P = "house.json";
        private static string N = "house.json";
        static void House()
        {
            while (true)
            {

                Console.WriteLine("Щоб видалити або змінити дані в пункті пошуку видеріть що саме ви хочете модифікувати");
                Console.WriteLine("\n\"додати дані нажми 'A'\nшукати дані нажми 'S'" + "\nпоказати всі дані нажми 'T'\nповернутися в головне меню 'Enter'\nClear console  нажми 'F'\nExit нажми 'Esc'");

                var data = JsonConvert.DeserializeObject<List<House_data>>(File.ReadAllText(P));
                if (Console.ReadKey().Key == ConsoleKey.A) // ДОДАТИ
                {
                    Console.Clear();
                    Console.WriteLine("Введіть дані квартиранта\n Прізвище : ");
                    string surname = Console.ReadLine();
                    Console.Write("Номер будинку: ");
                    string housenumber = Console.ReadLine();
                    Console.WriteLine("Номер квартири: ");
                    string flatnumber = Console.ReadLine();
                    Console.WriteLine("Стать: ");
                    string sex = Console.ReadLine();
                    Console.WriteLine("Сума боргу: ");
                    string suma = Console.ReadLine();

                    if (surname != null && housenumber != null && flatnumber != null && sex != null && suma != null)
                    {
                        data.Add(new House_data { Surname = surname, Housenumber = housenumber, Flatnumber = flatnumber, Sex = sex, Suma = suma });
                    }
                    else
                    {
                        Console.WriteLine("Будь ласка, заповніть всі поля");
                    }
                    Console.Clear();
                }
                if (Console.ReadKey().Key == ConsoleKey.F)//CLEAR
                {
                    Console.Clear();
                }
                if (Console.ReadKey().Key == ConsoleKey.S)//ПОШУК
                {
                    Console.Clear();
                    string surname;
                    Console.WriteLine("Введіть прізвище для пошуку: ");
                    surname = Console.ReadLine();
                    if (Console.ReadLine() != null)
                    {
                       
                        Console.Clear();
                        House_data FoundData = data.Find(found => found.Surname == surname);
                        if (FoundData ==null)
                        {
                            Console.WriteLine("Такого немає");
                        }
                        else
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("\tПрiзвище\t│  Номер будинку\t│  Номер квартири\t│\t\tСтать\t\t│\tСума\t");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");



                            Console.Write("\t" + FoundData.Surname + "\t");
                            Console.Write("\t\t " + FoundData.Housenumber + "\t");
                            Console.Write("\t\t " + FoundData.Flatnumber + "\t");
                            Console.Write("\t\t\t" + FoundData.Sex + "\t");
                            Console.Write("\t" + FoundData.Suma + "\t\n");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                            Console.WriteLine("\nДля редагування нажми 'E'");
                            Console.WriteLine("\n\nДля редагування видалення 'D'");
                            if (Console.ReadKey().Key == ConsoleKey.E)
                            {
                                Console.WriteLine("Ведіть дані \n Прізвище : ");

                                string surrname = Console.ReadLine();
                                Console.Write("Номер будинку: ");
                                string housenumber = Console.ReadLine();
                                Console.WriteLine("Номер квартири: ");
                                string flatnumber = Console.ReadLine();
                                Console.WriteLine("Стать: ");
                                string sex = Console.ReadLine();
                                Console.WriteLine("Сума: ");
                                string suma = Console.ReadLine();


                                if (surrname != null && housenumber != null && flatnumber != null && sex != null && suma != null)
                                {
                                    FoundData.Surname = surname;
                                    FoundData.Housenumber = housenumber;
                                    FoundData.Flatnumber = flatnumber;
                                    FoundData.Sex = sex;
                                    FoundData.Suma = suma;
                                    Console.Clear();
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("\tПрiзвище\t│  Номер будинку\t│  Номер квартири\t│\t\tСтать\t\t│\tСума\t");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");



                                    Console.Write("\t" + FoundData.Surname + "\t");
                                    Console.Write("\t\t " + FoundData.Housenumber + "\t");
                                    Console.Write("\t\t " + FoundData.Flatnumber + "\t");
                                    Console.Write("\t\t\t" + FoundData.Sex + "\t");
                                    Console.Write("\t" + FoundData.Suma + "\t\n");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                }

                            }
                            if (Console.ReadKey().Key == ConsoleKey.D)//DELETED
                            {
                                data.RemoveAll(x => x.Surname == surname);
                            }
                        }

                     
                    }
                    else
                    
                    {                        
                            Console.WriteLine("Введіть прізвище");
                        
                    }
                }
                if (Console.ReadKey().Key == ConsoleKey.T)//ВСІ ДАНІ
                {
                    Console.Clear();

                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\tПрiзвище\t│  Номер будинку\t│  Номер квартири\t│\t\tСтать\t\t│\tСума\t");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.Write("\t" + data[i].Surname + "\t");
                        Console.Write("\t\t " + data[i].Housenumber + "\t");
                        Console.Write("\t\t " + data[i].Flatnumber + "\t");
                        Console.Write("\t\t\t" + data[i].Sex + "\t");
                        Console.Write("\t\t" + data[i].Suma + "\t\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                    }

                    Console.WriteLine("\nСортувати дані за сумою нажми 'S'");

                    Console.WriteLine("\nСортувати дані за прізвищем нажми 'M'");
                    if (Console.ReadKey().Key == ConsoleKey.S)//Сортувати дані за прізвищем нажми
                    {

                        Console.Clear();
                        List<House_data> SortData = data.OrderByDescending(o => o.Suma).ToList();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("\tПрiзвище\t│  Номер будинку\t│  Номер квартири\t│\t\tСтать\t\t│\tСума\t");
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

                        for (int i = 0; i < data.Count; i++)
                        {

                            Console.Write("\t" + SortData[i].Surname + "\t");
                            Console.Write("\t\t " + SortData[i].Housenumber + "\t");
                            Console.Write("\t\t " + SortData[i].Flatnumber + "\t");
                            Console.Write("\t\t\t" + SortData[i].Sex + "\t");
                            Console.Write("\t" + SortData[i].Suma + "\t\n");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                        }
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");




                    }
                    if (Console.ReadKey().Key == ConsoleKey.M)//Сортувати дані за прізвищем нажми
                    {

                        Console.Clear();
                        List<House_data> SortData = data.OrderBy(o =>  o.Surname).ToList();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("\tПрiзвище\t│  Номер будинку\t│  Номер квартири\t│\t\tСтать\t\t│\tСума\t");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                        for (int i = 0; i < data.Count; i++)
                        {

                            Console.Write("\t" + SortData[i].Surname + "\t");
                            Console.Write("\t\t " + SortData[i].Housenumber + "\t");
                            Console.Write("\t\t " + SortData[i].Flatnumber + "\t");
                            Console.Write("\t\t\t" + SortData[i].Sex + "\t");
                            Console.Write("\t" + SortData[i].Suma + "\t\n");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                        }
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                        }
                    }
                    string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                    if (serialize.Count() > 1)
                    {
                        if (!File.Exists(N))
                        {
                            File.Create(N).Close();
                        }
                        File.WriteAllText(P, serialize, Encoding.UTF8);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            House();
        }


    }


}



    



