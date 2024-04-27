using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUI.Marker.ViewModels;

namespace MAUI.Marker.StudentMode;

public partial class PickStudentView : ContentPage
{
    public PickStudentView()
    {
        InitializeComponent();
        BindingContext = new PickStudentViewModel();
    }


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PickStudentViewModel)?.RefreshView();
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PickStudentViewModel)?.RefreshView();
    }

    private void SelectClicked(object sender, EventArgs e)
    {
        // save selected student id
        var studentId = (BindingContext as PickStudentViewModel)?.SelectedStudent?.Id;
        if(studentId != null)
        {
            Shell.Current.GoToAsync($"//StudentPage?studentId={studentId}");
        }
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void SearchClicked(object sender, EventArgs e)
    {
    }

    private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as PickStudentViewModel)?.RefreshView();
    }
}