using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3
{
    class Person
    {

        protected string name, lastName;

        private static int _counter = 0;

        public static int counter
        {
            get
            {
                return _counter;
            }

            private set
            {
                _counter = value;
            }
        }

        public Person(string name, string lastName)
        {

            this.name = name;

            this.lastName = lastName;

            counter++;

        }
        public string getPersonInfo() { return name + ", " + lastName; }

    };

    class Student : Person, IComparable<Student>
    {

        private string email;
        private string location;

        public Student(string name, string lastName, string location, string email)
            : base(name, lastName)
        {

            this.location = location;
            this.email = email;
        }

        public bool setName(string input)
        {

            if (input.Length < 2)
            {

                Console.WriteLine("Name must be at least two characters long");

                return false;

            }



            if (!input.All(Char.IsLetter))
            {

                Console.WriteLine("Name can only have letters");

                return false;

            }

            char[] chArray = input.ToCharArray();
            int count = 0;
            foreach (char c in chArray)
            {

                if (count == 0 && !char.IsUpper(c))
                {

                    Console.WriteLine("Name must start with an uppercase letter");
                    return false;

                }

                if (count != 0 && !char.IsLower(c))
                {
                    Console.WriteLine("All letter except first one must be lowercase!");
                    return false;
                }
                count++;
            }

            input = base.name;
            return true;
        }



        public string getStudentInfo()
        {
            return "Student " + base.name + " " + base.lastName + " from " + location + " with email " + email;
        }

        public string Email { get; set; }

        public string Location
        {
            get
            {
                if (location == "SA")
                {
                    location = "Sarajevo";
                }

                else if (location == "TZ")
                {
                    location = "Tuzla";
                }
                return location;

            }
            set
            {
                if (location == "SA" || location == "SARAJEVO" || location == "Sarajevo" || location == "sarajevo")
                {
                    location = "SA";
                }

                else if (location == "TZ" || location == "TUZLA" || location == "Tuzla" || location == "tuzla")
                {
                    this.location = "TZ";
                }
            }

        }

        public Student() : base(string.Empty, string.Empty) { }


        ~Student()
        {

        }
        public override string ToString()
        {
            return getStudentInfo();
        }

        public int CompareTo(Student other)
        {
            return this.location.CompareTo(other.location);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            
            List<Student> students = new List<Student>
                {
                  new Student("Fahro","Kuljaninovic","Tuzla","ef@live.com"),
                  new Student("Milan","Ibrahimovic","Tuzla","67ab@gmail.com"),
                  new Student("Semir","Isakovic","Sarajevo","semir@gmail.com"),
                  new Student("Djulaga","Kovacevic","Sarajevo","kovac@live.com"),
                  new Student("Armin","Muminovic","Tuzla","arm@gmail.com"),

                };
            
            students.Sort();
            students.ForEach(Student => Console.WriteLine(Student.getStudentInfo() + "\n"));
            Console.ReadLine();
        }
    }
}
   
