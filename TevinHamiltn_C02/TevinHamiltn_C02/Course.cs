using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamiltn_C02
{
    class Course
    {
        public string CourseTitle { get; set; }
        public Teacher TeacherAssigned { get; set; }
        public Student[] CourseStudents { get; set; }




        public Course(string title,int index)
        {
            CourseStudents = new Student[index];
            CourseTitle = title;
            Console.WriteLine("course created");
        }
        public string GetTitle()
        {
            return CourseTitle;
        }

    }
}
