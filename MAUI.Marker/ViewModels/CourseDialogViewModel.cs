using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Marker.Models;
using Library.Marker.Services;

namespace MAUI.Marker.ViewModels
{
    public class CourseDialogViewModel : INotifyPropertyChanged
    {
        // Constructor
        public CourseDialogViewModel(int cId)
        {
            IsDetailsVisible = true;
            IsModulesVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;

            if (cId == 0)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(cId) ?? new Course();
            }
        }


        // Course Details
        private Course course;

        public string Name 
        { 
            get { return course?.Name ?? string.Empty;} 
            set { 
                course ??= new Course();
                course.Name = value; 
            }
        }

        public string Code 
        { 
            get { return course?.Code ?? string.Empty; }
            set
            {
                course ??= new Course();
                course.Code = value;
            }
        }

        public string Description 
        { 
            get { return course?.Description ?? string.Empty; }
            set
            {
                course ??= new Course();
                course.Description = value;
            }
        }
        public void AddCourse()
        {
            if (course != null)
            {
                CourseService.Current.AddOrUpdate(course);
            }
        }

        // Roster Details
        public Person? SelectedStudent { get; set; }
        public Person? RosterSelected { get; set; }
        public ObservableCollection<Person> Roster
        {
            get
            {
                return new ObservableCollection<Person>(course.Roster ?? []);
            }
        }
        public ObservableCollection<Person> Students
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }

        public void AddStudentToCourse()
        {
            if(course != null && SelectedStudent != null)
            {
                course.Roster?.Add(SelectedStudent);
            }
        }

        public void RemoveStudentFromCourse()
        {
            if(course != null && RosterSelected != null)
            {
                course.Roster?.Remove(RosterSelected);
            }
        }

        // Module Details



        // Assignment Details

        public Assignment? SelectedAssignment { get; set; }

        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(course.Assignments ?? []);
            }
        }

        public void AddAssignment()
        {
            // TODO: Implement
            if(course != null)
            {
                course.Assignments ??= new List<Assignment>();
                course.Assignments.Add(new Assignment());
            }
        }

        public void RemoveAssignment()
        {
            if(course != null && SelectedAssignment != null)
            {
                course.Assignments?.Remove(SelectedAssignment);
            }
        }


        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsDetailsVisible { get; set; }
        public bool IsModulesVisible { get; set; }
        public bool IsRosterVisible { get; set; }
        public bool IsAssignmentsVisible { get; set; }
        public void ShowDetails()
        {
            IsDetailsVisible = true;
            IsModulesVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;
            NotifyPropertyChanged(nameof(IsDetailsVisible));
            NotifyPropertyChanged(nameof(IsModulesVisible));
            NotifyPropertyChanged(nameof(IsRosterVisible));
            NotifyPropertyChanged(nameof(IsAssignmentsVisible));
        }
        public void ShowModules()
        {
            IsDetailsVisible = false;
            IsModulesVisible = true;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;
            NotifyPropertyChanged(nameof(IsDetailsVisible));
            NotifyPropertyChanged(nameof(IsModulesVisible));
            NotifyPropertyChanged(nameof(IsRosterVisible));
            NotifyPropertyChanged(nameof(IsAssignmentsVisible));
        }
        public void ShowRoster()
        {
            IsDetailsVisible = false;
            IsModulesVisible = false;
            IsRosterVisible = true;
            IsAssignmentsVisible = false;
            NotifyPropertyChanged(nameof(IsDetailsVisible));
            NotifyPropertyChanged(nameof(IsModulesVisible));
            NotifyPropertyChanged(nameof(IsRosterVisible));
            NotifyPropertyChanged(nameof(IsAssignmentsVisible));
        }
        public void ShowAssignments()
        {
            IsDetailsVisible = false;
            IsModulesVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = true;
            NotifyPropertyChanged(nameof(IsDetailsVisible));
            NotifyPropertyChanged(nameof(IsModulesVisible));
            NotifyPropertyChanged(nameof(IsRosterVisible));
            NotifyPropertyChanged(nameof(IsAssignmentsVisible));
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Roster));
            NotifyPropertyChanged(nameof(Students));
            NotifyPropertyChanged(nameof(SelectedStudent));
            NotifyPropertyChanged(nameof(RosterSelected));
            NotifyPropertyChanged(nameof(Assignments));
            NotifyPropertyChanged(nameof(SelectedAssignment));
        }
    }
}
