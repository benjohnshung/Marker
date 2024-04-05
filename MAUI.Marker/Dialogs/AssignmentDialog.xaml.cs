using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUI.Marker.ViewModels;

namespace MAUI.Marker.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class AssignmentDialog : ContentPage
{
    public int CourseId { get; set; }
    public AssignmentDialog()
    {
        InitializeComponent();
        BindingContext = new AssignmentDialogViewModel(CourseId);
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentDialogViewModel)?.AddAssignment();
        Shell.Current.GoToAsync("//CourseDialog?courseId={CourseId}");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDialog?courseId={CourseId}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AssignmentDialogViewModel(CourseId);
        (BindingContext as AssignmentDialogViewModel)?.RefreshView();
    }
}


