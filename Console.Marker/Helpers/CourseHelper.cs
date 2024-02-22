using Library.Marker.Models;
using Library.Marker.Services;

namespace App.Marker.Helpers
{
    public class CourseHelper
    {
        private CourseService courseSvc = CourseService.Current;
        private StudentService studentSvc = StudentService.Current;
        public void AddCourse()
        {
            Console.WriteLine("Enter Course Code:");
            var code = Console.ReadLine();
            Console.WriteLine("Enter Course Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Course Description:");
            var description = Console.ReadLine();
            var roster = new List<Person>();
            var assignments = new List<Assignment>();
            var modules = new List<Module>();

            Course newCourse = new Course { Code = code, Name = name, Description = description, Roster = roster, Assignments = assignments, Modules = modules };

            courseSvc.Add(newCourse);
        }
        public void AddStudentToCourse(Course CourseToUpdate)
        {
            if (CourseToUpdate.Roster == null || studentSvc.Students.Count() == 0)
            {
                Console.WriteLine("There are currently no students.");
                return;
            }

            int count = 0;
            studentSvc.Students.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            Console.WriteLine("Select a Student");
            var choice = Console.ReadLine();
            Person StudentToAdd;

            if (int.TryParse(choice, out int intChoice))
            {
                StudentToAdd = studentSvc.Students.ElementAt(intChoice - 1);
                Console.WriteLine($"{StudentToAdd}");
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return;
            }

            if (CourseToUpdate.Roster != null) CourseToUpdate.Roster.Add(StudentToAdd);
        }
        public void UpdateCourse()
        {
            int count = 0;
            courseSvc.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            Console.WriteLine("Select a Course");
            var choice = Console.ReadLine();
            Course CourseToUpdate;

            if (int.TryParse(choice, out int intChoice))
            {
                CourseToUpdate = courseSvc.Courses.ElementAt(intChoice - 1);
                Console.WriteLine($"{CourseToUpdate}");
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return;
            }

            Console.WriteLine(CourseToUpdate);

            Console.WriteLine("Please select a number:");
            Console.WriteLine("1 -- Update Course Code");
            Console.WriteLine("2 -- Update Course Name");
            Console.WriteLine("3 -- Update Course Description");
            Console.WriteLine("4 -- Update Course Roster");
            Console.WriteLine("5 -- Update Course Assignments");
            Console.WriteLine("6 -- Update Course Modules");

            choice = Console.ReadLine();

            if (int.TryParse(choice, out int intUpdate))
            {
                switch (intUpdate)
                {
                    case 1:
                        UpdateCourseCode(CourseToUpdate);
                        break;
                    case 2:
                        UpdateCourseName(CourseToUpdate);
                        break;
                    case 3:
                        UpdateCourseDescription(CourseToUpdate);
                        break;
                    case 4:
                        UpdateCourseRoster(CourseToUpdate);
                        break;
                    case 5:
                        UpdateCourseAssignments(CourseToUpdate);
                        break;
                    case 6:
                        UpdateCourseModules(CourseToUpdate);
                        break;
                }
            }
        }

        private void UpdateCourseCode(Course CourseToUpdate)
        {
            Console.WriteLine($"Current course code:{CourseToUpdate.Code}");
            Console.WriteLine("Please enter new course code:");

            string? codeInput = Console.ReadLine();

            while (codeInput == null)
            {
                Console.WriteLine("Please try again.");
                codeInput = Console.ReadLine();
            }

            CourseToUpdate.Code = codeInput;
            Console.WriteLine("Course Code change success!");
        }
        private void UpdateCourseName(Course CourseToUpdate)
        {
            Console.WriteLine($"Current course Name:{CourseToUpdate.Name}");
            Console.WriteLine("Please enter new course name:");

            string? input = Console.ReadLine();

            while (input == null)
            {
                Console.WriteLine("Please try again.");
                input = Console.ReadLine();
            }

            CourseToUpdate.Name = input;
            Console.WriteLine("Course Name change success!");
        }
        private void UpdateCourseDescription(Course CourseToUpdate)
        {
            Console.WriteLine($"Current course description:{CourseToUpdate.Description}");
            Console.WriteLine("Please enter new course description:");

            string? input = Console.ReadLine();

            while (input == null)
            {
                Console.WriteLine("Please try again.");
                input = Console.ReadLine();
            }

            CourseToUpdate.Description = input;
            Console.WriteLine("Course Description change success!");
        }
        private void UpdateCourseRoster(Course CourseToUpdate)
        {
            Console.WriteLine("Did you want to (a)dd or (r)emove a student");
            string? choiceInput = Console.ReadLine();

            while (choiceInput == null)
            {
                Console.WriteLine("Please try again.");
                choiceInput = Console.ReadLine();
            }

            switch (choiceInput)
            {
                case "A":
                case "a":
                    if (CourseToUpdate.Roster == null || studentSvc.Students.Count() == 0)
                    {
                        Console.WriteLine("There are currently no students.");
                        break;
                    }

                    int count = 0;
                    studentSvc.Students.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

                    Console.WriteLine("Select a Student");
                    var choice = Console.ReadLine();
                    Person StudentToAdd;

                    if (int.TryParse(choice, out int intChoice))
                    {
                        StudentToAdd = studentSvc.Students.ElementAt(intChoice - 1);
                        Console.WriteLine($"{StudentToAdd}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice");
                        return;
                    }

                    if (CourseToUpdate.Roster != null) CourseToUpdate.Roster.Add(StudentToAdd);
                    break;
                case "R":
                case "r":
                    if (CourseToUpdate.Roster == null || CourseToUpdate.Roster.Count == 0)
                    {
                        PrintRoster(CourseToUpdate);
                    }
                    else
                    {
                        Console.WriteLine("This class is currently empty!");
                        break;
                    }

                    Console.WriteLine("Select a Student");
                    var removeChoice = Console.ReadLine();
                    Person StudentToRemove;

                    if (int.TryParse(removeChoice, out int intRemove))
                    {
                        StudentToRemove = studentSvc.Students.ElementAt(intRemove - 1);
                        Console.WriteLine($"{StudentToRemove}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice");
                        return;
                    }

                    if (CourseToUpdate.Roster != null) CourseToUpdate.Roster.Remove(StudentToRemove);

                    break;
                default:
                    break;
            }
        }
        private void UpdateCourseAssignments(Course CourseToUpdate) { }
        private void UpdateCourseModules(Course CourseToUpdate) { }

        // private void AddStudentToCourse(Student StudentToAdd)
        // {
        //     if (StudentToAdd == null) return;
        //     if (studentSvc.Students.Count() == 0)
        //     {
        //         Console.WriteLine("There are currently no students.");
        //         return;
        //     }
        //     Console.WriteLine("Please select a student by entering a number:");
        //     Program.ListStudents(ref studentsList);
        //     string? idS = Console.ReadLine();

        //     while (idS == null)
        //     {
        //         Console.WriteLine("Please try again.");
        //         idS = Console.ReadLine();
        //     }

        //     Person? currentSelectedStudent = studentsList.Find(x => x.ID == int.Parse(idS));

        //     Course? currentSelectedCourse;
        //     Console.WriteLine("First, select a course by entering the course code:");

        //     ListCourses(ref coursesList);
        //     string? userInput = Console.ReadLine();

        //     while (userInput == null)
        //     {
        //         Console.WriteLine("Please try again.");
        //         userInput = Console.ReadLine();
        //     }

        //     currentSelectedCourse = coursesList.Find(x => x.Code == userInput);

        //     while (currentSelectedCourse == null)
        //     {
        //         Console.WriteLine($"{userInput} does not exist. Please try again.");
        //         userInput = Console.ReadLine();
        //         currentSelectedCourse = coursesList.Find(x => x.Code == userInput);
        //     }

        //     currentSelectedCourse.PrintAllInfo();

        //     if (currentSelectedCourse.Roster != null && currentSelectedStudent != null && currentSelectedStudent.Courses != null && currentSelectedStudent.Grades != null)
        //     {
        //         currentSelectedCourse.Roster.Add(currentSelectedStudent);
        //         currentSelectedStudent.Courses.Add(currentSelectedCourse);
        //         currentSelectedStudent.Grades.Add(0);
        //     }
        //     else
        //     {
        //         Console.WriteLine("Could not find course. Bye.");
        //     }
        // }
        private void PrintRoster(Course CourseToUpdate)
        {
            if (CourseToUpdate.Roster != null)
            {
                foreach (var student in CourseToUpdate.Roster)
                {
                    Console.WriteLine($"{student.ID} | {student.Name} | {student.Classification}");
                }
            }
        }

        public void ListCourses()
        {
            int count = 0;
            courseSvc.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));
        }
    }
}
