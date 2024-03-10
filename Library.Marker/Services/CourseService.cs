using Library.Marker.Models;
using Library.Marker.Database;
using System.Diagnostics;

namespace Library.Marker.Services
{
    public class CourseService
    {
        private string? query;
        private static object _lock = new object();
        private static CourseService? instance;
        public static CourseService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new CourseService();
                    }
                }

                return instance;
            }
        }


        private CourseService()
        {

        }

        public List<Course> Courses
        {
            get
            {
                return FakeDatabase.Courses;
            }
        }

        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(Courses =>
                           (Courses.Name ?? string.Empty).ToUpper().Contains(query ?? string.Empty) ||
                                          (Courses.Code ?? string.Empty).ToUpper().Contains(query ?? string.Empty) ||
                                                         (Courses.Description ?? string.Empty).ToUpper().Contains(query ?? string.Empty));
        }


        public void Add(Course courseToAdd)
        {
            FakeDatabase.Courses.Add(courseToAdd);
        }
        public void Delete(Course courseToDelete)
        {
            FakeDatabase.Courses.Remove(courseToDelete);
        }

        public void Update(Course courseToUpdate)
        {
            var course = FakeDatabase.Courses.FirstOrDefault(c => c.Code == courseToUpdate.Code);
            if (course != null)
            {
                course.Code = courseToUpdate.Code;
                course.Name = courseToUpdate.Name;
                course.Description = courseToUpdate.Description;
            }
        }
    }
}
