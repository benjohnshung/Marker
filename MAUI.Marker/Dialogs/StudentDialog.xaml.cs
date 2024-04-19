using Library.Marker.Services;
using MAUI.Marker.ViewModels;

namespace MAUI.Marker.Dialogs;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class StudentDialog : ContentPage
{
    public int StudentId
    {
        get; set;
    }
    public StudentDialog()
    {
        InitializeComponent();
        BindingContext = new StudentDialogViewModel(0);
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDialogViewModel)?.AddStudent();
        Shell.Current.GoToAsync("//Students");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Students");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDialogViewModel(StudentId);
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = new StudentDialogViewModel(StudentId);
    }
}
