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

    // Course Details
    private async void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddCourse();
        Shell.Current.GoToAsync("//Courses");
        //await DisplayAlert("Course Added", "Course has been added", "OK");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel(CourseId);
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel(CourseId);
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }

    // Toolbar
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

    // Roster
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

    // Assignments
    private void AddAssignmentClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowAssignmentEdit();
    }

    private void RemoveAssignmentClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.RemoveAssignment();
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }
    
    private void EditAssignmentOkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddAssignment();
        (BindingContext as CourseDialogViewModel)?.ShowAssignments();
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }

    private void EditAssignmentCancelClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowAssignments();
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }

    // Modules

    private void AddModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowModuleAdd();
    }

    private void EditModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowModuleEdit();
        (BindingContext as CourseDialogViewModel)?.RefreshView();
    }

    private void RemoveModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.RemoveModule();
        (BindingContext as CourseDialogViewModel)?.RefreshView(); 
    }

    private void AddNewModuleOkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddModule();
        (BindingContext as CourseDialogViewModel)?.ShowModules();
        (BindingContext as CourseDialogViewModel)?.RefreshView();

    }

    private void AddNewModuleCancelClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.ShowModules();
    }

}
