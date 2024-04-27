using MAUI.Marker.ViewModels;
using Library.Marker.Services;

namespace MAUI.Marker.Views;

public partial class StudentView : ContentPage
{
    public StudentView()
    {
        InitializeComponent();
        BindingContext = new StudentViewModel();
    }

    private void AddStudentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//StudentDialog?studentId=0");
    }

    private void EditStudentClicked(object sender, EventArgs e)
    {
        var studentId = (BindingContext as StudentViewModel)?.SelectedStudent?.Id;
        if (studentId != null)
        {
            Shell.Current.GoToAsync($"//StudentDialog?studentId={studentId}");
        }
    }

    private void RemoveStudentClicked(object sender, EventArgs e)
    {
        StudentService.Current.Delete((BindingContext as StudentViewModel)?.SelectedStudent);
        (BindingContext as StudentViewModel)?.ResetView();
        (BindingContext as StudentViewModel)?.RefreshView();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as StudentViewModel)?.ResetView();
        (BindingContext as StudentViewModel)?.RefreshView();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
    }

    private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as StudentViewModel)?.RefreshView();
    }
}
