using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Marker.Models;
using MAUI.Marker.ViewModels;

namespace MAUI.Marker.StudentMode;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class StudentPage : ContentPage
{
    public int StudentId { get; set; }
    public StudentPage()
    {
        InitializeComponent();
        BindingContext = new StudentPageViewModel(StudentId);
        (BindingContext as StudentPageViewModel)?.RefreshView();
    }
    private void CourseClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentPageViewModel)?.RefreshView();
    }

    private void ModuleClicked(object sender, EventArgs e)
    {
    }

    private void AssignmentClicked(object sender, EventArgs e)
    {
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PickStudentView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentPageViewModel(StudentId);
        (BindingContext as StudentPageViewModel)?.RefreshView();
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentPageViewModel(StudentId);
        (BindingContext as StudentPageViewModel)?.RefreshView();
    }
}
