using Library.Marker.Models;

namespace Library.Marker.Services
{
    public class CourseService
    {
        private IList<Course> courses;
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
        public IEnumerable<Course> Courses
        {
            get
            {
                return courses.Where(
                    c =>
                    (c.Name ?? string.Empty).ToUpper().Contains(query ?? string.Empty)
                    || (c.Code ?? string.Empty).ToUpper().Contains(query ?? string.Empty));
            }
        }

        private CourseService()
        {
            courses = new List<Course>();
        }

        public IEnumerable<Course> Search(string query)
        {
            this.query = query;
            return Courses;
        }
        public void Add(Course courseToAdd)
        {
            courses.Add(courseToAdd);
        }
        public void Delete(Course courseToDelete)
        {
            courses.Remove(courseToDelete);
        }
        public void List()
        {
            int count = 0;
            courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));
        }

    }
}
