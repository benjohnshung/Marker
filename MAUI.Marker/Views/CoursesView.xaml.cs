using MAUI.Marker.ViewModels;

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
        Shell.Current.GoToAsync("//CourseAddEdit");
    }

    private void EditCourseClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//AddCourse");
    }
    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//AddCourse");
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
