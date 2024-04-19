using System.ComponentModel;
using Library.Marker.Models;
using Library.Marker.Services;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MAUI.Marker.ViewModels
{
    public class StudentDialogViewModel
    {
        private Person student;
        public string Name { 
            get { return student?.Name ?? string.Empty; }
            set
            {
                if (student == null) student = new Person();
                student.Name = value;
            } 
        }
        public string ClassificationString { 
            get { return ClassToString(student.Classification) ?? string.Empty;} 
            set
            {
                if(student == null) student = new Person();
                student.Classification = StringToClass(value);
            }
        }
        public int Id { get; set; }

        public StudentDialogViewModel(int cId)
        {
            if(cId == 0)
            {
                student = new Person();
            } else
            {
                student = StudentService.Current.GetById(cId) ?? new Person();
            }
        }

        public void LoadById(int id)
        {
            if(id == 0) { return; }
            var person = StudentService.Current.GetById(id) as Person;
            if(student != null)
            {
                Name = student.Name;
                Id = student.Id;
                ClassificationString = ClassToString(student.Classification);
            }

        }

        public void AddStudent()
        {
            if(student != null)
            {
                student.Classification = StringToClass(ClassificationString);
                StudentService.Current.AddOrUpdate(student);
            }
        }

        private ClassificationType StringToClass(string s)
        {
            ClassificationType classification;
            switch (s)
            {
                case "Freshman":
                    classification = ClassificationType.Freshman;
                    break;
                case "Sophomore":
                    classification = ClassificationType.Sophomore;
                    break;
                case "Junior":
                    classification = ClassificationType.Junior;
                    break;
                case "Senior":
                    classification = ClassificationType.Senior;
                    break;
                default:
                    classification = ClassificationType.Freshman;
                    break;
            }
            return classification;
        }
        private string ClassToString(ClassificationType? c)
        {
            string classification;
            switch (c)
            {
                case ClassificationType.Freshman:
                    classification = "Freshman";
                    break;
                case ClassificationType.Sophomore:
                    classification = "Sophomore";
                    break;
                case ClassificationType.Junior:
                    classification = "Junior";
                    break;
                case ClassificationType.Senior:
                    classification = "Senior";
                    break;
                default:
                    classification = "Freshman";
                    break;
            }
            return classification;
        }
    }
}
