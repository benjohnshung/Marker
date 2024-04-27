using MAUI.Marker.ViewModels;
using Library.Marker.Services;
using Library.Marker.Models;
using Library.Marker.Database;

namespace MAUI.Marker.Views;
public partial class CoursesView : ContentPage
{
    private readonly AppDbContext _dbContext = new AppDbContext();
    public CoursesView()
    {
        InitializeComponent();
        BindingContext = new CoursesViewModel();
        _dbContext.SaveChanges();

}

private void AddCourseClicked(object sender, EventArgs e)
    {
        var courseId = 0;
        Shell.Current.GoToAsync($"//CourseDialog?courseId={courseId}");
        _dbContext.SaveChanges();
    }

private void EditCourseClicked(object sender, EventArgs e)
    {
        var courseId = (BindingContext as CoursesViewModel)?.SelectedCourse?.Id;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//CourseDialog?courseId={courseId}");
        }
        _dbContext.SaveChanges();
    }
    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        CourseService.Current.Delete((BindingContext as CoursesViewModel)?.SelectedCourse);
        (BindingContext as CoursesViewModel)?.ResetView();
        (BindingContext as CoursesViewModel)?.RefreshView();
        _dbContext.SaveChanges();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
        _dbContext.SaveChanges();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CoursesViewModel)?.ResetView();
        (BindingContext as CoursesViewModel)?.RefreshView();
        _dbContext.SaveChanges();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
    }

    private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as CoursesViewModel)?.RefreshView();
        _dbContext.SaveChanges();
    }
}
