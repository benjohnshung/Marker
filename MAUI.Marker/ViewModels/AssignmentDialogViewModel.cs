using Library.Marker.Services;
using Library.Marker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUI.Marker.ViewModels
{
    public class AssignmentDialogViewModel : INotifyPropertyChanged
    {
        public AssignmentDialogViewModel(int cId)
        {
            newAssignment = new Assignment();
            if(cId != 0)
            {
                course = CourseService.Current.Get(cId) ?? new Course();
            }
        }
         
        private Course course;
        private Assignment newAssignment;
        public string Name
        {
            get { return newAssignment?.Name ?? string.Empty; }
            set
            {
                newAssignment ??= new Assignment();
                newAssignment.Name = value;
            }
        }

        public string Description
        {
            get { return newAssignment?.Description ?? string.Empty; }
            set
            {
                newAssignment ??= new Assignment();
                newAssignment.Description = value;
            }
        }

        public int TotalPoints
        {
            get { return newAssignment.TotalAvailablePoints; }
            set
            {
                newAssignment.TotalAvailablePoints = value;
            }
        }

        public DateTime DueDate
        {
            get { return newAssignment.DueDate; }
            set
            {
                newAssignment.DueDate = value;
            }
        }

        public void AddAssignment()
        {
            course.Assignments.Add(newAssignment);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(newAssignment));
        }
    }
}
