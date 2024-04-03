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
        private Course course;
        public Person SelectedStudent { get; set; }
        public Person RosterSelected { get; set; }
        public string Name 
        { 
            get { return course?.Name ?? string.Empty;} 
            set { 
                if (course == null) course = new Course();
                course.Name = value; 
            }
        }

        public string Code 
        { 
            get { return course?.Code ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Code = value;
            }
        }

        public string Description 
        { 
            get { return course?.Description ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Description = value;
            }
        }
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
        public bool IsDetailsVisible { get; set; }
        public bool IsModulesVisible { get; set; }
        public bool IsRosterVisible { get; set; }
        public bool IsAssignmentsVisible { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CourseDialogViewModel(int cId)
        {
            IsDetailsVisible = true;
            IsModulesVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;

            if(cId == 0)
            {
                course = new Course();
            } else {
                course = CourseService.Current.Get(cId) ?? new Course();
            }
        }

        public void AddCourse()
        {
            if(course != null)
            {
                CourseService.Current.AddOrUpdate(course);
            }
        }

        public void AddStudentToCourse()
        {
            if(course != null)
            {
                course.Roster.Add(SelectedStudent);
            }
        }

        public void RemoveStudentFromCourse()
        {
            if(course != null)
            {
                course.Roster.Remove(RosterSelected);
            }
        }

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
        }
    }
}
