using MAUI.Marker.ViewModels;

namespace MAUI.Marker.Views;
public partial class CoursesView : ContentPage
{
    public CoursesView()
    {
        InitializeComponent();
        BindingContext = new CoursesViewModel();
    }
    
    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            Shell.Current.GoToAsync($"//CourseDetail?code={((Course)e.SelectedItem).Code}");
            (BindingContext as CoursesViewModel).ListCourses(Shell.Current);
        }
    }
    private void AddCourses_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddCourse");
    }
}
