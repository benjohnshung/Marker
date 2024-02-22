using MAUI.Marker.ViewModels;

namespace MAUI.Marker.Views;

public partial class AddCourseView : ContentPage
{
    public AddCourseView()
    {
        InitializeComponent();
        BindingContext = new AddCourseViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as AddCourseViewModel).AddCourse(Shell.Current);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }
}

