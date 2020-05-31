using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    interface test_inter
    {
       string Indent(int count);
       string TopIndent(int count);
    }
    abstract class Library : test_inter
    {
        public abstract string Indent(int count);
        public abstract string TopIndent(int count);
        

        public string Name { get; set; }
        public string Address { get; set; }

    }
    class WorkingDay : Library
    {
        public DateTime Date { get; set; }
        public int BookOutCount { get; set; }
        public int BookInCount { get; set; }
        public override string Indent(int count)
        {
            if (count > 0)
            {
                return "".PadLeft(count);
            }
            return "";
        }
        public override string TopIndent(int count)
        {
            string a = "";
            for (int i = 0; i < count; i++)
            {
                a += "\n";
            }
            return a;
        }
    }
    class Program 
    {

        static int TD = 25;
        static int UTD = 5;
        static void Main(string[] args)
        {

            string path = "FILE.json";
            List<WorkingDay> Days = ReadFile(path);
            while (true)
            {
                Console.Clear();
                Show(Days);
                var k = Console.ReadKey().Key;
                Console.Clear();
                switch (k)
                {
                    case ConsoleKey.A:
                        if (Days == null)
                        {
                            Days = new List<WorkingDay>();
                            Days.Add(CreateNewDay());
                        }
                        else
                        {
                            Days.Add(CreateNewDay());
                        }
                        break;
                    case ConsoleKey.D:
                        DelteDay(Days);
                        break;
                    case ConsoleKey.C:
                        ChangeData(Days);
                        break;
                    case ConsoleKey.Enter:
                        return;
                        break;
                    case ConsoleKey.M:
                        MidlleBookMove(Days);
                        break;
                    case ConsoleKey.B:
                        CountOfBookMore(Days);
                        break;
                    case ConsoleKey.P:
                        PairReturned(Days);
                        break;

                }
                SaveFile(path, Days);
            }

        }
        static void Show(List<WorkingDay> a)
        {
            string LibName = "[ Lib Name ]";
            string Adress = "[  Adress  ]";
            string Date = "[   Date   ]";
            string BookOut = "[Book out]";
            string Bookin = "[Book in]"; 
            Library lib = new WorkingDay();
           
                        Console.WriteLine(lib.TopIndent(UTD) + lib.Indent(TD) + LibName + Adress + Date + BookOut + Bookin);
            if (a != null && a.Count > 0)
            {
                foreach (WorkingDay Day in a)
                {
                    Console.WriteLine(lib.Indent(TD) + "[" + Day.Name + lib.Indent(LibName.Length - 2 - Day.Name.Length) + "]"
                        + "[" + Day.Address + lib.Indent(Adress.Length - 2 - Day.Address.Length) + "]"
                        + "[" + Day.Date.ToString("dd/MM/yyyy") + lib.Indent(Date.Length - 2 - Day.Date.Date.ToString("dd/MM/yyyy").Length) + "]"
                        + "[" + Day.BookOutCount + lib.Indent(BookOut.Length - 2 - Day.BookOutCount.ToString().Length) + "]"
                        + "[" + Day.BookInCount + lib.Indent(Bookin.Length - 2 - Day.BookInCount.ToString().Length) + "]");
                }
            }
            Console.WriteLine(lib.TopIndent(1) + lib.Indent(TD) + "Press [A - To add new day][D - Delete day][C - Change day]");
            Console.WriteLine(lib.Indent(TD) + "[M - The average movement of books per day for the period]");
            Console.WriteLine(lib.Indent(TD) + "[B - The number of days books were published than were returned]");
            Console.WriteLine(lib.Indent(TD) + "[P - Days when an even number of books are published and returned are odd]");
        }
        public static List<WorkingDay> ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            List<WorkingDay> Ret = new List<WorkingDay>();
            Ret = JsonConvert.DeserializeObject<List<WorkingDay>>(File.ReadAllText(path));
            return Ret;
        }
        public static void SaveFile(string path, List<WorkingDay> data)
        {
            string serialize = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                File.WriteAllText(path, serialize, Encoding.UTF8);
            }
        }
       
        public static WorkingDay CreateNewDay()
        {
            Console.Clear();
            WorkingDay Day = new WorkingDay();
            Console.WriteLine("Enter Name of library");
            Day.Name = Console.ReadLine();
            Console.WriteLine("Enter adress of library");
            Day.Address = Console.ReadLine();
            Console.WriteLine("Enter date of day like 01.02.2000");
            Day.Date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
            Console.WriteLine("Enter Book in count");
            Day.BookInCount = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Book out count");
            Day.BookOutCount = Convert.ToInt16(Console.ReadLine());
            return Day;
        }
        public static void DelteDay(List<WorkingDay> Days)
        {
            if (Days != null)
            {
                Console.WriteLine("Enter date of day that`s you want to delete");
                var s = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
                Days.RemoveAll(x => x.Date == s);

            }
        }
        public static void ChangeData(List<WorkingDay> Days)
        {
            Console.WriteLine("Enter date of day that`s you want to change");
            var s = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
            WorkingDay day = Days.Find(x => x.Date == s);
            if (day != null)
            {
                Console.WriteLine("Enter value of day that`s you want to change \n1)Name\n2)Adress\n3)Date like 01.02.2000\n4)Book Out\n5)Book In");
                char a = Console.ReadKey().KeyChar;
                Console.WriteLine("Enter new value");
                switch (a)
                {
                    case '1':
                        day.Name = Console.ReadLine();
                        break;
                    case '2':
                        day.Address = Console.ReadLine();
                        break;
                    case '3':
                        day.Date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
                        break;
                    case '4':
                        day.BookOutCount = Convert.ToInt16(Console.ReadLine());
                        break;
                    case '5':
                        day.BookInCount = Convert.ToInt16(Console.ReadLine());
                        break;
                }
            }
        }
        //
        public static void MidlleBookMove(List<WorkingDay> Days)
        {
            Console.Clear();
            Console.WriteLine("Enter earlier date like 01.02.2000");
            var date1 = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
            Console.WriteLine("Enter later date like 01.02.2000");
            var date2 = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
            for (int i = 0; i < Days.Count; i++)
            {
                for (int k = 0; k < Days.Count; k++)
                {
                    if (Days[i].Date < Days[k].Date)
                    {
                        var Temp = Days[k];
                        Days[k] = Days[i];
                        Days[i] = Temp;
                    }
                }
            }
            float count = 0;
            float Move = 0;
            for (int i = 0; i < Days.Count; i++)
            {
                if (Days[i].Date > date1 && Days[i].Date < date2)
                {
                    Move += (Days[i].BookInCount + Days[i].BookOutCount);
                    count++;
                }
            }
            Console.WriteLine("The average movement of books per day for the period :" + Move / count);
            Console.ReadKey();
        }
        public static void CountOfBookMore(List<WorkingDay> Days)
        {
            List<WorkingDay> Cut = new List<WorkingDay>();
            foreach (WorkingDay d in Days)
            {
                if (d.BookInCount < d.BookOutCount)
                {
                    Cut.Add(d);
                }
            }
            Show(Cut);
            Console.ReadKey();
        }
        public static void PairReturned(List<WorkingDay> Days)
        {
            List<WorkingDay> Cut = new List<WorkingDay>();
            foreach (WorkingDay d in Days)
            {
                if (d.BookOutCount % 2 == 0 && d.BookInCount % 2 != 0)
                {
                    Cut.Add(d);
                }
            }
            Show(Cut);
            Console.ReadKey();
        }
    }
}

