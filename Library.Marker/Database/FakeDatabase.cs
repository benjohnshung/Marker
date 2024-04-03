using Library.Marker.Models;

namespace Library.Marker.Database
{
    public static class FakeDatabase
    {
        private static List<Person> students = new List<Person>();
        private static List<Course> courses = new List<Course>();
        public static List<Person> Students
        {
            get
            {
                return students;
            }
        }

        public static List<Course> Courses
        {
            get
            {
                return courses;
            }
        }
    }
}