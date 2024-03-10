using MAUI.Marker.ViewModels;
using System.Diagnostics;

namespace MAUI.Marker.Views;

[QueryProperty(nameof(Edit), "edit")]
[QueryProperty(nameof(Code), "code")]
public partial class CourseAddEditView : ContentPage
{
    public CourseAddEditView()
    {
        InitializeComponent();
        BindingContext = new CourseAddEditViewModel();
        (BindingContext as CourseAddEditViewModel).ifEdit(edit, code);
    }

    string edit;
    public string Edit
    {
        get => edit;
        set
        {
            edit = value;
            OnPropertyChanged();
        }
    }

    string code;
    public string Code
    {
        get => code;
        set
        {
            code = value;
            OnPropertyChanged();
        }
    }

    private void OkClicked(object sender, EventArgs e)
    {
        if (edit == "true")
        {
            (BindingContext as CourseAddEditViewModel).EditCourse(Shell.Current);
        }
        else
        {
            (BindingContext as CourseAddEditViewModel).AddCourse(Shell.Current);
        }
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Courses");
    }
}

