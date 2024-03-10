using Library.Marker.Models;
using Library.Marker.Services;

namespace MAUI.Marker.ViewModels
{
    class CourseAddEditViewModel
    {
        public CourseAddEditViewModel()
        {
            course = new Course();
        }

        private Course course;

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

        public void ifEdit(string edit, string code)
        {
            if (edit == "true")
            {
                course = (Course)CourseService.Current.Search(code);
            }
        }

        public void AddCourse(Shell s)
        {
            Course newCourse = new Course
            {
                Code = this.Code,
                Name = this.Name,
                Description = this.Description
            };
            CourseService.Current.Add(newCourse);
            s.GoToAsync("//Courses");
        }

        public void EditCourse(Shell s)
        {
            CourseService.Current.Update(course);
            s.GoToAsync("//Courses");
        }
    }
}
