using App.Marker.Helpers;

namespace Marker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var courseHlpr = new CourseHelper();
            var studentHlpr = new StudentHelper();

            string? choice = "0";
            while (choice != "q")
            {
                // Printing Menu
                Console.WriteLine("Please choose from the menu below");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("ac: Add a Course");
                Console.WriteLine("as: Add a Student");
                Console.WriteLine("asc: Add Student to a Course");
                Console.WriteLine("rsr: Remove Student from Course Roster");
                Console.WriteLine("lc: List all Courses");
                Console.WriteLine("sc: Look up Course");
                Console.WriteLine("ls: List all Students");
                Console.WriteLine("ss: Look up Student");
                Console.WriteLine("uc: Update a Course's Information");
                Console.WriteLine("us: Update a Student's Information");
                Console.WriteLine("ca: Create an Assignment and Add to Course");
                Console.WriteLine("------------------------------------------");

                // Take input
                choice = Console.ReadLine();
                while (choice == null)
                {
                    Console.WriteLine("Please enter a valid option.");
                    choice = Console.ReadLine();
                }

                // Menu Logic
                switch (choice)
                {
                    case "ac":
                        Console.WriteLine("ac");
                        courseHlpr.AddCourse();
                        break;
                    case "as":
                        Console.WriteLine("as");
                        studentHlpr.AddStudent();
                        break;
                    case "asc":
                        Console.WriteLine("asc");
                        //AddStudentToCourse(ref CoursesList, ref StudentsList);
                        break;
                    case "rsr":
                        Console.WriteLine("rsr");
                        //RemoveStudentFromCourse(ref CoursesList);
                        break;
                    case "lc":
                        Console.WriteLine("lc");
                        courseHlpr.ListCourses();
                        break;
                    case "sc":
                        Console.WriteLine("sc");
                        //LookUpCourse(ref CoursesList);
                        break;
                    case "ls":
                        Console.WriteLine("ls");
                        studentHlpr.ListStudents();
                        break;
                    case "ss":
                        Console.WriteLine("ss");
                        //LookUpStudent(ref StudentsList);
                        break;
                    case "uc":
                        Console.WriteLine("uc");
                        courseHlpr.UpdateCourse();
                        break;
                    case "us":
                        Console.WriteLine("us");
                        //studentHlpr.UpdateStudent();
                        break;
                    case "ca":
                        Console.WriteLine("ca");
                        //CreateAssignment(ref CoursesList);
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}