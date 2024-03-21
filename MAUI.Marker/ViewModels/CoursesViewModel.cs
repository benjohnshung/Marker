using Library.Marker.Models;
using Library.Marker.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUI.Marker.ViewModels
{
    public class CoursesViewModel : INotifyPropertyChanged
    {
        public CoursesViewModel() {
            IsCoursesVisible = true;
        }
        public bool IsCoursesVisible
        {
            get; set;
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }
        public void ShowCourses()
        {
            IsCoursesVisible = true;
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public Course SelectedCourse { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetView()
        {
            //Query = string.Empty;
            //NotifyPropertyChanged(nameof(Query));
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Courses));
            NotifyPropertyChanged(nameof(SelectedCourse));
        }
    }
}
