using MAUI.Marker.ViewModels;
using Library.Marker.Services;

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
        Shell.Current.GoToAsync($"//CourseAddEdit?edit=false,code={string.Empty}");
    }

    private void EditCourseClicked(object sender, EventArgs e)
    {
        string currentCode = (BindingContext as CoursesViewModel).SelectedCourse.Code;
        Shell.Current.GoToAsync($"//CourseAddEdit?edit=true,code={currentCode}");
    }
    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        CourseService.Current.Delete((BindingContext as CoursesViewModel).SelectedCourse);
        (BindingContext as CoursesViewModel).ResetView();
        (BindingContext as CoursesViewModel).RefreshView();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CoursesViewModel).ResetView();
        (BindingContext as CoursesViewModel).RefreshView();
    }
}
