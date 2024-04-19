using Library.Marker.Models;
using Library.Marker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MAUI.Marker.ViewModels;

internal class StudentPageViewModel : INotifyPropertyChanged
{

    public StudentPageViewModel(int id)
    {
        if (id == 0)
        {
            currentStudent = new Person();
        }
        else
        {
            currentStudent = StudentService.Current.GetById(id);
        }
        RefreshView();
    }

    public Person currentStudent { get; set; }
    public Course currentCourse { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void RefreshView()
    {
        NotifyPropertyChanged(nameof(StudentCourses));

        NotifyPropertyChanged(nameof(currentStudent));
        NotifyPropertyChanged(nameof(currentCourse));

        NotifyPropertyChanged(nameof(CourseModules));
        NotifyPropertyChanged(nameof(CourseAssignments));
    }


    public ObservableCollection<Course> StudentCourses
    {
        get
        {
            return new ObservableCollection<Course>(currentStudent.CurrentCourses);
        }
    }

    public ObservableCollection<Module> CourseModules
    {
        get
        {
            if(currentCourse != null)
            {
                return new ObservableCollection<Module>(currentCourse.Modules);
            } else {
                return new ObservableCollection<Module>();
            }
        }
    }
    public ObservableCollection<Assignment> CourseAssignments
    {
        get
        {
            if (currentCourse != null)
            {
                return new ObservableCollection<Assignment>(currentCourse.Assignments);
            } else {                 
                return new ObservableCollection<Assignment>();
            }
        }
    }



}
