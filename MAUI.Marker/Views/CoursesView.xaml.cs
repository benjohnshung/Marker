using MAUI.Marker.ViewModels;
using Library.Marker.Services;
using Library.Marker.Models;

namespace MAUI.Marker.Views;
public partial class CoursesView : ContentPage
{
    public CoursesView()
    {
        InitializeComponent();
        BindingContext = new CoursesViewModel();

    }
    
    private void AddCourseClicked(object sender, EventArgs e)
    {
        var courseId = 0;
        Shell.Current.GoToAsync($"//CourseDialog?courseId={courseId}");
    }

    private void EditCourseClicked(object sender, EventArgs e)
    {
        var courseId = (BindingContext as CoursesViewModel)?.SelectedCourse?.Id;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//CourseDialog?courseId={courseId}");
        }
    }
    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        CourseService.Current.Delete((BindingContext as CoursesViewModel)?.SelectedCourse);
        (BindingContext as CoursesViewModel)?.ResetView();
        (BindingContext as CoursesViewModel)?.RefreshView();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CoursesViewModel)?.ResetView();
        (BindingContext as CoursesViewModel)?.RefreshView();
    }
}
