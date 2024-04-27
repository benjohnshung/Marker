using Library.Marker.Models;
using Library.Marker.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUI.Marker.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public StudentViewModel()
        {
            IsStudentsVisible = true;
        }
        public bool IsStudentsVisible
        {
            get; set;
        }
        public ObservableCollection<Person> Students
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students.ToList().Where(c => c.Name.Contains(Query ?? "")));
            }
        }
        public void ShowStudents()
        {
            IsStudentsVisible = true;
            NotifyPropertyChanged("IsStudentsVisible");
        }
        public Person SelectedStudent { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Students));
            NotifyPropertyChanged(nameof(SelectedStudent));
        }

        public string Query { get; set; }
    }
}
