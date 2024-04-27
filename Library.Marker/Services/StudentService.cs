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
                return _dbContext.Students;
            }
        }
        private readonly AppDbContext _dbContext = CourseService.Current._dbContext;

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
                _dbContext.Students.Add(studentToAdd);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Person studentToDelete)
        {
            _dbContext.Students.Remove(studentToDelete);
            _dbContext.SaveChanges();
        }

        public Person? GetById(int id)
        {
            return _dbContext.Students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Course> GetStudentCourses(Person student)
        {
            return _dbContext.Courses.Where(c => c.Roster.Contains(student));
        }
    }
}
