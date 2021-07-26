using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamiltn_C02
{
    class Main
    {
        private Menu _menu = new Menu();
        private Course _currentCourse = null;

        public Main()
        {
            _menu = new Menu("Create Courae","Create teacher","Add students","display","Exit");
            _menu.Title = "Course Track";
            Display();
        }
        private void SelectOption()
        {
            switch (Utility.IntValidate("\nPlease make a selection"))
            {
                case 1:
                    CreateCourse();
                    break;
                case 2:
                    if (_currentCourse == null) { Console.WriteLine("please create a course."); Console.ReadKey(); Display(); }
                    else { CreateTeacher(); }
                    break;
                case 3:
                    if (_currentCourse == null) { Console.WriteLine("please create a course."); Console.ReadKey(); Display(); }
                   else { AddStudent(); }
                    break;
                case 4:
                    if (_currentCourse == null) { Console.WriteLine("please create a course."); Console.ReadKey(); Display(); }
                    else { ClassDisplay(); }
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    SelectOption();
                    break;
            }
            
        }
        private void Display()
        {
            _menu.Display();
            SelectOption();
        }
        private void CreateCourse()
        {
            string courseName = Utility.StringValidate("Enter the course title\r\n");
            int studentNum = Utility.IntValidate("\r\nPlease enter the number of students that will attend the class");           
            Course course1 = new Course(courseName,studentNum);
            _currentCourse = course1;
            Console.WriteLine("\r\nplease press enter to return to menu ");
            Console.ReadKey();
            Display();
        }
        private void CreateTeacher()
        {
            string name = Utility.StringValidate("Please enter teacher name.\r\n");
            int age = Utility.IntValidate("please enter teacher age.\r\n");
            int knowledgeNum = Utility.IntValidate("\r\nplease enter the amount of knowlegde you would like to answer for the teacher");
            string[] knowledgeArray = new string[knowledgeNum];
            for (int i = 0; i < knowledgeArray.Length; i++)
            {
                string newKnowledge = Utility.StringValidate("please enter teacher knowledge\r\n");
                knowledgeArray[i] = newKnowledge;
            }
            Teacher teacher = new Teacher(name, age,knowledgeArray);
            _currentCourse.TeacherAssigned = teacher;
            Console.WriteLine("\r\nplease press any key to contuine");
            Console.ReadKey();
            Display();
        }
        private void AddStudent()
        {
            int amountOfStudents = _currentCourse.CourseStudents.Length;
            Student[] studentArray = new Student[amountOfStudents];
            for (int i = 0; i < amountOfStudents; i++)
            {
                string studentName = Utility.StringValidate("Please enter the student name\r\n");
                int studentAge = Utility.IntValidate("What is the age of the student\r\n");
                int studentGrades = Utility.IntValidate("What is the current grade of this student\r\n");
                Student newStudent = new Student(studentName,studentAge,studentGrades);
                studentArray[i] = newStudent;
            }
            //Course.SetStudentsAttending(studentArray);
            _currentCourse.CourseStudents = studentArray;

            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
            Display();
        }
        private void ClassDisplay()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Course info");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"course title: {_currentCourse.GetTitle()}, Number of students: {_currentCourse.CourseStudents.Length}" +
                $"\r\nCourse teacher info:\r\nName:{_currentCourse.TeacherAssigned.Name}, Age:{_currentCourse.TeacherAssigned.Age}\r\n ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Teacher background");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in _currentCourse.TeacherAssigned.Background)
            {Console.WriteLine(item);}
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\r\nStudents attending course");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in _currentCourse.CourseStudents)
            {  Console.WriteLine(item.ToString()); }
            Console.WriteLine("\r\nPress enter to return to the menu.");
            Console.ReadLine();
            Display();
        }
        private void Exit()
        {
            Environment.Exit(0);
            Console.ReadKey();
        }
    }
}
