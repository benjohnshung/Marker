using Library.Marker.Models;
using Library.Marker.Database;
using System.Diagnostics;

namespace Library.Marker.Services
{
    public class CourseService
    {
        private int LastId
        {
            get
            {
                if (Courses.Count() == 0)
                {
                    return 0;
                }
                else
                {
                    return Courses.Select(c => c.Id).Max();
                }
            }
        }

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

        public IEnumerable<Course> Courses
        {
            //get
            //{
            //    return Courses.Where(c =>
            //               (c.Name ?? string.Empty).ToUpper().Contains(query ?? string.Empty) ||
            //                              (c.Code ?? string.Empty).ToUpper().Contains(query ?? string.Empty) ||
            //                                             (c.Description ?? string.Empty).ToUpper().Contains(query ?? string.Empty));
            //}
            get
            {
                return FakeDatabase.Courses;
            }
        }

        public IEnumerable<Course> Search(string query)
        {
            this.query = query;
            return Courses;
        }


        public void AddOrUpdate(Course courseToAdd)
        {
            if (courseToAdd.Id <= 0)
            {
                courseToAdd.Id = LastId + 1;
            }
            FakeDatabase.Courses.Add(courseToAdd);
        }
        public void Delete(Course courseToDelete)
        {
            FakeDatabase.Courses.Remove(courseToDelete);
        }

        public Course? Get(int id)
        {
            return FakeDatabase.Courses.FirstOrDefault(c => c.Id == id);
        }
    }
}
