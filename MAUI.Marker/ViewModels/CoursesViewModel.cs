using Library.Marker.Models;
using Library.Marker.Services;

namespace MAUI.Marker.ViewModels
{
    class CoursesViewModel
    {
        public CoursesViewModel() {
            List<Course>? Courses = new List<Course>();
        }

        private Course course;
        public void ListCourses(Shell s)
        {
            CourseService.Current.List();
        }
    }
}
