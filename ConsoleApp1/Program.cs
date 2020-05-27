using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp4
{
    interface IStrings
    {
       Dictionary<Data_Base, int> Main2(List<Data_Base> d_b);
       
    }
    ///
    class Data_Base
    {
        private string ACCOUNT_NUMBER;
        private string Name_LastName;
        private float total;
        private string Data;
        public List<string> Dates = new List<string>(); //для зберігання декількох дат якщо ми з'єднуємо два об'єкта ( потрібно для сортування по кількості операцій )

        public string Name
        {
            get { return Name_LastName; }
            set { Name_LastName = value; }
        }
        public float Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }
        public string DaTa
        {
            get
            {
                return Data;
            }
            set
            {
                Data = value;
            }
        }
        public string Number
        {
            get
            {
                return ACCOUNT_NUMBER;
            }
            set
            {
                ACCOUNT_NUMBER = value;
            }
        }


        public Dictionary<Data_Base, int> Main2(List<Data_Base> d_b)
        {

            Dictionary<Data_Base, int> Count = new Dictionary<Data_Base, int>();
            foreach (Data_Base x in d_b)
            {
                List<Data_Base> Namess = Count.Keys.ToList();
                bool tr = true;

                foreach (Data_Base s in Namess)
                {
                    if (s.Name == x.Name)
                    {
                        Count[s]++;
                        tr = false;
                        s.Dates.Add(x.DaTa);
                    }
                }

                if (tr)
                {
                    Count.Add(x, 1);
                }
            }
            return Count;
        }



    }
  
    class Program
    {
      
        static void Main()
        {

            List<Data_Base> d_b = new List<Data_Base>();


            d_b.Add(new Data_Base { Name = "name_1", Total = 240.50f, DaTa = "18.08.07", Number = "22344678918345" });
            d_b.Add(new Data_Base { Name = "name_3", Total = 242.0f, DaTa = "18.05.18", Number = "12345678982375" });
            d_b.Add(new Data_Base { Name = "name_2", Total = 420.0f, DaTa = "19.11.20", Number = "15345678712345" });
            d_b.Add(new Data_Base { Name = "name_2", Total = 761.0f, DaTa = "01.11.20", Number = "15345678712345" });
            d_b.Add(new Data_Base { Name = "name_4", Total = 342.0f, DaTa = "19.11.20", Number = "92345778912344" });
            d_b.Add(new Data_Base { Name = "name_3", Total = 468.0f, DaTa = "18.11.19", Number = "12345678982375" });
            d_b.Add(new Data_Base { Name = "name_3", Total = 777.0f, DaTa = "29.11.18", Number = "12345678982375" });
            d_b.Add(new Data_Base { Name = "name_3", Total = 277.0f, DaTa = "29.11.15", Number = "12345678982375" });
            d_b.Add(new Data_Base { Name = "name_3", Total = 140.0f, DaTa = "19.11.19", Number = "12345678982375" });
            d_b.Add(new Data_Base { Name = "name_4", Total = 241.0f, DaTa = "19.11.20", Number = "92345778912344" });



            Data_Base s = new Data_Base();
            Dictionary<Data_Base, int> Count = s.Main2(d_b);



            List<Data_Base> Names = Count.Keys.ToList();
            List<int> values = Count.Values.ToList();
            int cnt = Names.Count;
            for (int i = 0; i < cnt; i++)
            {
                int d = values.IndexOf(values.Max());
                if (d >= 0)
                {
                    Console.WriteLine($"\nName - {Names[d].Name}, Operations {values[d]}, Num - {Names[d].Number}, \nDate: ");
                    Console.Write(Names[d].DaTa + ";   ");
                    foreach (string p in Names[d].Dates)
                    {
                        Console.Write(p + ";   ");
                    }
                    Console.WriteLine(" ");
                }
                Names.RemoveAt(d); values.RemoveAt(d);
            }
            Console.ReadKey();




        }




    }
}
