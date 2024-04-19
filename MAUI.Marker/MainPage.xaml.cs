using MAUI.Marker.ViewModels;

namespace MAUI.Marker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void InstructorViewButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InstructorView");
        }

        private void StudentViewButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//PickStudentView");
        }
    }

}
