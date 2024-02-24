using MAUI.Marker.ViewModels;

namespace MAUI.Marker.Views;

public partial class CourseAddEditView : ContentPage
{
    public CourseAddEditView()
    {
        InitializeComponent();
        BindingContext = new CourseAddEditViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseAddEditViewModel)?.AddCourse(Shell.Current);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }
}

