using Library.Marker.Models;
using Library.Marker.Services;

namespace MAUI.Marker.ViewModels
{
    class AddCourseViewModel
    {
        public AddCourseViewModel()
        {
            course = new Course();
        }
        public string Code
        {
            get => course?.Code ?? string.Empty;
            set { if (course != null) course.Code = value; }
        }
        public string Name
        {
            get => course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }
        public string Description
        {
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }

        private Course course;

        public void AddCourse(Shell s)
        {
            CourseService.Current.Add(course);
            s.GoToAsync("//Courses");
        }
    }
}
