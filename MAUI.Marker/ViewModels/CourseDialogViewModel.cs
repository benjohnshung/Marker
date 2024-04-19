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
            ShowDetails();
            if (cId == 0)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(cId) ?? new Course();
            }
            RefreshView();
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
                SelectedStudent.CurrentCourses.Add(course);
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

        public Module SelectedModule { get; set; }

        public ObservableCollection<Module> Modules
        {
            get
            {
                return new ObservableCollection<Module>(course.Modules ?? []);
            }
        }


        // All Modules view
        public void RemoveModule()
        {
            if (course != null && SelectedModule != null)
            {
                course.Modules?.Remove(SelectedModule);
            }
        }

            // Add Module view
        private Module module;
        public string NewModuleName
        {
            get { return module?.Name ?? string.Empty; }
            set
            {
                module ??= new Module();
                module.Name = value;
            }
        }

        public string NewModuleDescription
        {
            get { return module?.Description ?? string.Empty; }
            set
            {
                module ??= new Module();
                module.Description = value;
            }
        }

        public void AddModule()
        {
            if(course != null)
            {
                course.Modules ??= new List<Module>();
                Module newModule = new Module();
                newModule.Name = NewModuleName;
                newModule.Description = NewModuleDescription;
                course.Modules.Add(newModule);
            }
            NewModuleName = string.Empty;
            NewModuleDescription = string.Empty;
            RefreshView();
        }
        // Edit Module view
        public string NewContentItemName { get; set; }
        public string NewContentItemDescription { get; set; }
        public ObservableCollection<ContentItem> ModuleContent
        {
            get
            {
                return new ObservableCollection<ContentItem>(SelectedModule.Content ?? []);
            }
        }
        public Module ContentItemSelectedModule { get; set; }
        public void AddContentItem()
        {
            if (ContentItemSelectedModule != null)
            {
                ContentItemSelectedModule.Content ??= new List<ContentItem>();
                ContentItem newContentItem = new ContentItem();
                newContentItem.Name = NewContentItemName;
                newContentItem.Description = NewContentItemDescription;
                newContentItem.Path = "";
                ContentItemSelectedModule.Content.Add(newContentItem);
            }
            NewContentItemName = string.Empty;
            NewContentItemDescription = string.Empty;
            RefreshView();
        }

        // Assignment Details

        public Assignment? SelectedAssignment { get; set; }

        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(course.Assignments ?? []);
            }
        }

        public void RemoveAssignment()
        {
            if(course != null && SelectedAssignment != null)
            {
                course.Assignments?.Remove(SelectedAssignment);
            }
        }

        private Assignment newAssignment;
        public string newAssignmentName
        {
            get { return newAssignment?.Name ?? string.Empty; }
            set
            {
                newAssignment ??= new Assignment();
                newAssignment.Name = value;
            }
        }

        public string newAssignmentDescription
        {
            get { return newAssignment?.Description ?? string.Empty; }
            set
            {
                newAssignment ??= new Assignment();
                newAssignment.Description = value;
            }
        }

        public int newAssignmentTotalPoints
        {
            get {
                if (newAssignment == null)
                {
                    return 100;
                }
                return newAssignment.TotalAvailablePoints; 
            }
            set
            {
                newAssignment ??= new Assignment();
                newAssignment.TotalAvailablePoints = value;
            }
        }

        public DateTime newAssignmentDueDate
        {
            get {
                if (newAssignment == null)
                {
                    return DateTime.Now;
                }
                return newAssignment.DueDate; 
            }
            set
            {
                newAssignment ??= new Assignment();
                newAssignment.DueDate = value;
            }
        }

        public void AddAssignment()
        {
            if (course != null)
            {
                course.Assignments ??= new List<Assignment>();
                Assignment newAssignment = new Assignment();
                newAssignment.Name = newAssignmentName;
                newAssignment.Description = newAssignmentDescription;
                newAssignment.TotalAvailablePoints = newAssignmentTotalPoints;
                newAssignment.DueDate = newAssignmentDueDate;
                course.Assignments.Add(newAssignment);
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
        public bool IsModulesAddVisible { get; set; }
        public bool IsModulesEditVisible { get; set; }
        public bool IsRosterVisible { get; set; }
        public bool IsAssignmentsVisible { get; set; }
        public bool IsAssignmentsEditVisible { get; set; }

        public void ShowDetails()
        {
            IsDetailsVisible = true;

            IsModulesVisible = false;
            IsModulesAddVisible = false;
            IsModulesEditVisible = false;
            
            IsRosterVisible = false;
            
            IsAssignmentsVisible = false;
            IsAssignmentsEditVisible = false;

            RefreshView();
        }
        public void ShowModules()
        {
            IsDetailsVisible = false;
            IsModulesVisible = true;
            IsModulesAddVisible = false;
            IsModulesEditVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;
            IsAssignmentsEditVisible = false;
            RefreshView();

        }
        public void ShowRoster()
        {
            IsDetailsVisible = false;
            IsModulesVisible = false;
            IsModulesAddVisible = false;
            IsModulesEditVisible = false;
            IsRosterVisible = true;
            IsAssignmentsVisible = false;
            IsAssignmentsEditVisible = false;
            RefreshView();

        }
        public void ShowAssignments()
        {
            IsDetailsVisible = false;
            IsModulesVisible = false;
            IsModulesAddVisible = false;
            IsModulesEditVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = true;
            IsAssignmentsEditVisible = false;
            RefreshView();

        }

        public void ShowModuleAdd()
        {
            IsDetailsVisible = false;
            IsModulesVisible = false;
            IsModulesAddVisible = true;
            IsModulesEditVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;
            IsAssignmentsEditVisible = false;
            RefreshView();

        }

        public void ShowModuleEdit()
        {
            // make new module equal the selected module
            ContentItemSelectedModule = SelectedModule;
            IsDetailsVisible = false;
            IsModulesVisible = false;
            IsModulesAddVisible = false;
            IsModulesEditVisible = true;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;
            IsAssignmentsEditVisible = false;
            RefreshView();

        }
        public void ShowAssignmentEdit()
        {
            IsDetailsVisible = false;
            IsModulesVisible = false;
            IsModulesAddVisible = false;
            IsModulesEditVisible = false;
            IsRosterVisible = false;
            IsAssignmentsVisible = false;
            IsAssignmentsEditVisible = true;
            RefreshView();
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(IsDetailsVisible));
            NotifyPropertyChanged(nameof(IsModulesVisible));
            NotifyPropertyChanged(nameof(IsModulesAddVisible));
            NotifyPropertyChanged(nameof(IsModulesEditVisible));
            NotifyPropertyChanged(nameof(IsRosterVisible));
            NotifyPropertyChanged(nameof(IsAssignmentsVisible));
            NotifyPropertyChanged(nameof(IsAssignmentsEditVisible));

            NotifyPropertyChanged(nameof(Roster));
            NotifyPropertyChanged(nameof(Students));

            NotifyPropertyChanged(nameof(SelectedStudent));
            NotifyPropertyChanged(nameof(RosterSelected));

            NotifyPropertyChanged(nameof(Assignments));
            NotifyPropertyChanged(nameof(SelectedAssignment));

            NotifyPropertyChanged(nameof(Modules));
            //NotifyPropertyChanged(nameof(SelectedModule));  
            NotifyPropertyChanged(nameof(NewContentItemName));  
            NotifyPropertyChanged(nameof(NewContentItemDescription));  
            NotifyPropertyChanged(nameof(ModuleContent));
        }
    }
}