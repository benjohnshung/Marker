using Library.Marker.Models;

namespace Library.Marker.Services
{
    public class StudentService
    {
        private IList<Person> students;
        private string? query;
        private static object _lock = new object();
        private static StudentService? instance;
        public static StudentService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new StudentService();
                    }
                }

                return instance;
            }
        }
        public IEnumerable<Person> Students
        {
            get
            {
                return students.Where(
                c =>
                        (c.Name ?? string.Empty).ToUpper().Contains(query ?? string.Empty));
            }
        }

        private StudentService()
        {
            students = new List<Person>();
        }

        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Students;
        }

        public void Add(Person studentToAdd)
        {
            students.Add(studentToAdd);
        }

        public void Delete(Person studentToDelete)
        {
            students.Remove(studentToDelete);
        }
    }
}
