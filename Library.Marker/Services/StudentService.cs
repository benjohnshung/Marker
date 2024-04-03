using Library.Marker.Database;
using Library.Marker.Models;

namespace Library.Marker.Services
{
    public class StudentService
    {

        private int LastId
        {
            get
            {
                if (Students.Count() == 0)
                {
                    return 0;
                }
                else
                {
                    return Students.Select(c => c.Id).Max();
                }
            }
        }

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
                return FakeDatabase.Students;
            }
        }

        private StudentService()
        {
        }

        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Students;
        }

        public void AddOrUpdate(Person studentToAdd)
        {
            if(studentToAdd.Id <= 0)
            {
                studentToAdd.Id = LastId + 1;
                FakeDatabase.Students.Add(studentToAdd);
            }
        }

        public void Delete(Person studentToDelete)
        {
            FakeDatabase.Students.Remove(studentToDelete);
        }

        public Person? GetById(int id)
        {
            return FakeDatabase.Students.FirstOrDefault(s => s.Id == id);
        }


    }
}
