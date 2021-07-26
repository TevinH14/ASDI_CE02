using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamiltn_C02
{
    class Student:Person
    {
        public int Grade { get; set; }

        public Student(string name ,int age ,int grade):base(name,age)
        {
            Grade = grade;
            Console.WriteLine("student created");
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Grade: {Grade }";
        }
    }
}
