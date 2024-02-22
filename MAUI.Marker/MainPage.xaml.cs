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

        private void CoursesBtn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Courses");
        }
    }

}
