using Library.Marker.Database;
using Library.Marker.Models;
using Library.Marker.Services;
using Microsoft.EntityFrameworkCore;
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
    private readonly AppDbContext dbContext = CourseService.Current._dbContext;
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
        DefaultViewVisible = true;
        SubmitAssignmentViewVisible = false;
        ShowDefaultView();
    }

    public Person currentStudent { get; set; }
    public Course currentCourse { get; set; }
    public Assignment SelectedAssignment { get; set; }
    public Assignment AssignmentToSubmit { get; set; }

    public bool DefaultViewVisible { get; set; }
    public bool SubmitAssignmentViewVisible { get; set; }
    public string SubmissionText { get; set; } = "";

    public void SubmitAssignment()
    {
        AssignmentToSubmit = SelectedAssignment;
        Submission newSubmission = new Submission();
        newSubmission.Text = SubmissionText;
        newSubmission.Student = currentStudent;
        newSubmission.Grade = -1;
         if (AssignmentToSubmit.Submissions == null)
        {
            AssignmentToSubmit.Submissions = new List<Submission>();
        }
        AssignmentToSubmit.Submissions.Add(newSubmission);
        SubmissionText = "";
        ShowDefaultView();
        dbContext.SaveChanges();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void ShowSubmitAssignment()
    {
        AssignmentToSubmit = SelectedAssignment;
        DefaultViewVisible = false;
        SubmitAssignmentViewVisible = true;
        NotifyPropertyChanged(nameof(DefaultViewVisible));
        NotifyPropertyChanged(nameof(AssignmentToSubmit));
        NotifyPropertyChanged(nameof(SubmitAssignmentViewVisible));
    }

    public void ShowDefaultView()
    {
        AssignmentToSubmit = SelectedAssignment;
        DefaultViewVisible = true;
        SubmitAssignmentViewVisible = false;
        NotifyPropertyChanged(nameof(DefaultViewVisible));
        NotifyPropertyChanged(nameof(SubmitAssignmentViewVisible));
    }
    public void RefreshView()
    {
        NotifyPropertyChanged(nameof(currentCourse));

        NotifyPropertyChanged(nameof(CourseModules));
        NotifyPropertyChanged(nameof(CourseAssignments));

        NotifyPropertyChanged(nameof(DefaultViewVisible));
        NotifyPropertyChanged(nameof(SubmitAssignmentViewVisible));
        NotifyPropertyChanged(nameof(SelectedAssignment));
    }


    public ObservableCollection<Course> StudentCourses
    {
        get
        {
            return new ObservableCollection<Course>(StudentService.Current.GetStudentCourses(currentStudent));
        }
    }

    public ObservableCollection<Module> CourseModules
    {
        get
        {
            if(currentCourse != null)
            {
                return new ObservableCollection<Module>(CourseService.Current.GetCourseModules(currentCourse));
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
                return new ObservableCollection<Assignment>(CourseService.Current.GetCourseAssignments(currentCourse));
            } else {                 
                return new ObservableCollection<Assignment>();
            }
        }
    }



}
