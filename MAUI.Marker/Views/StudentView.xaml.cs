using MAUI.Marker.ViewModels;

namespace MAUI.Marker.Views
{
    public partial class StudentView : ContentPage
    {
        public StudentView()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }
    }
}
