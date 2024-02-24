using MAUI.Marker.ViewModels;


namespace MAUI.Marker.Views
{
    public partial class InstructorView : ContentPage
    {
        public InstructorView()
        {
            InitializeComponent();
            BindingContext = new InstructorViewModel();
        }
        private void CoursesButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Courses");
        }

        private void StudentsButtonClicked(object sender, EventArgs e)
        {
            //Shell.Current.GoToAsync("//Students");
        }
    }
}