using Library.Marker.Services;
using MAUI.Marker.ViewModels;

namespace MAUI.Marker.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDialog : ContentPage
{
    public int CourseId
    {
        get; set;
    }
    public CourseDialog()
    {
        InitializeComponent();
        BindingContext = new CourseDialogViewModel(0);
    }
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddCourse();
        Shell.Current.GoToAsync("//Courses");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel(CourseId);
    }

    private void Toolbar_DetailsClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowDetails();
    }
    private void Toolbar_RosterClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowRoster();
    }
    private void Toolbar_ModulesClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowModules();
    }
    private void Toolbar_AssignmentsClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowAssignments();
    }

    private void AddStudentToRosterClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddStudentToCourse();
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }

    private void RemoveFromRosterClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.RemoveStudentFromCourse();
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }
}
