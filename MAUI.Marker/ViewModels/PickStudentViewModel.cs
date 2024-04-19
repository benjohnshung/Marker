using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Marker.Models;
using Library.Marker.Services;

namespace MAUI.Marker.ViewModels;

public class PickStudentViewModel : INotifyPropertyChanged
{
    public PickStudentViewModel()
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
            return new ObservableCollection<Person>(StudentService.Current.Students);
        }
    }
    public Person SelectedStudent { get; set; }

    public void ShowStudents()
    {
        IsStudentsVisible = true;
        NotifyPropertyChanged("IsStudentsVisible");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void RefreshView()
    {
        NotifyPropertyChanged(nameof(Students));
        NotifyPropertyChanged(nameof(SelectedStudent));
    }



}
