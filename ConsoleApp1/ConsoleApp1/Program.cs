using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
   
        class student
        {
            private string name;
            private string lastName;
            private string group;
            private string year;
            private string adress;
            private string passport;
            private string age;
            private string telehone;
            private string rating;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    lastName = value;
                }
            }
            public string Group
            {
                get
                {
                    return group;
                }
                set
                {
                    group = value;
                }
            }
            public string Year
            {
                get
                {
                    return year;
                }
                set
                {
                    year = value;
                }
            }
            public string Adress
            {
                get
                {
                    return adress;
                }
                set
                {
                    adress = value;
                }
            }
            public string Passport
            {
                get
                {
                    return passport;
                }
                set
                {
                    passport = value;
                }
            }
            public string Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }
            public string Telehone
            {
                get
                {
                    return telehone;
                }
                set
                {
                    telehone = value;
                }
            }
            public string Rating
            {
                get
                {
                    return rating;
                }
                set
                {
                    rating = value;
                }
            }
        }

        public class Program
        {
        
             
        static void Main()
            {
            student student = new student();
          

         
                Console.Write("Name : ");
                student.Name = Console.ReadLine();
                Console.Write("LastName : ");
                student.LastName = Console.ReadLine();
                Console.Write("Group : ");
                student.Group = Console.ReadLine();
                Console.Write("Year : ");
                student.Year = Console.ReadLine();
                Console.Write("Adress : ");
                student.Adress = Console.ReadLine();
                Console.Write("Passport : ");
                student.Passport = Console.ReadLine();
                Console.Write("Age : ");
                student.Age = Console.ReadLine();
                Console.Write("Telehone : ");
                student.Telehone = Console.ReadLine();
                Console.Write("Rating : ");
                student.Rating = Console.ReadLine();
                string Raiting = student.Rating;

                Console.WriteLine();
                Console.WriteLine("Name \t\t: " + student.Name);
                Console.WriteLine("LastName\t: " + student.LastName);
                Console.WriteLine("Group\t\t: " + student.Group);
                Console.WriteLine("Year\t\t: " + student.Year);
                Console.WriteLine("Adress\t\t: " + student.Adress);
                Console.WriteLine("Passport\t: " + student.Passport);
                Console.WriteLine("Age\t\t: " + student.Age);
                Console.WriteLine("Telephone\t: " + student.Telehone);
                Console.WriteLine("Rating\t\t: " + student.Rating);


                Rating_write(Convert.ToInt32(Raiting));

            }
            public static int Rating_write(int R)
            {
                if (R > 75 && R < 90)
                {
                    Console.WriteLine("\nМожна вчитися краще");
                return 3;

            }
            if (R < 75)
                {
                    Console.WriteLine("\nВарто бiльше уваги придiляти навчанню");
                return 2;


            }
            if (R >= 90)
                {
                    Console.WriteLine("\nВiтаємо вiдмiнника");
                return 1;

            }
            return 0;
        }

        }
    }

