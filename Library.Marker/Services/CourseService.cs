using Library.Marker.Models;
using Library.Marker.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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

        public readonly AppDbContext _dbContext = new AppDbContext();
        private CourseService()
        {
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                return _dbContext.Courses;
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
                _dbContext.Courses.Add(courseToAdd);
                _dbContext.SaveChanges();
            }
        }
        public void Delete(Course courseToDelete)
        {
            _dbContext.Courses.Remove(courseToDelete);
            _dbContext.SaveChanges();
        }

        public Course? Get(int id)
        {
            return _dbContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Person> GetCourseRoster(Course course)
        {
            if (course == null)
            {
                return new Collection<Person>();
            }
            var entry = _dbContext.Entry(course);
            entry.Collection(c => c.Roster).Load();
            return entry.Entity.Roster;
        }
        
        public IEnumerable<Module> GetCourseModules(Course course)
        {
            if (course == null)
            {
                return new Collection<Module>();
            }
            var entry = _dbContext.Entry(course);
            entry.Collection(c => c.Modules).Load();
            return entry.Entity.Modules;
        }

        public IEnumerable<Assignment> GetCourseAssignments(Course course)
        {
            if(course == null)
            {
                return new Collection<Assignment>();
            }
            var entry = _dbContext.Entry(course);
            entry.Collection(c => c.Assignments).Load();
            return entry.Entity.Assignments;
        }

        public IEnumerable<Submission> GetAssignmentSubmissions(Assignment assignment)
        {
            if (assignment == null)
            {
                return new Collection<Submission>();
            }
            var entry = _dbContext.Entry(assignment);
            entry.Collection(a => a.Submissions).Load();
            return entry.Entity.Submissions;
        }
    }
}
