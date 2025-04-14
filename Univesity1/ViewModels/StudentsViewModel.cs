using System.Collections.ObjectModel;
using UniversityApp.Models;

namespace UniversityApp.WPF.ViewModels
{
    public class StudentsViewModel
    {
        public ObservableCollection<Student> Students { get; set; }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
            }
        }

        public StudentsViewModel()
        { 
            Students = new ObservableCollection<Student>
            {
                new Student
                {
                    RecordBookNumber = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Patronymic = "Иванович",
                    GroupID = 1,
                    Group = new Group
                    {
                        ID = 1,
                        Abbreviation = "ИВТ",
                        Faculty = "ФКН",
                        Specialty = "Информатика и ВТ",
                        YearOfAdmission = 2021
                    }
                } // Потом подключить к DB
            };
        }
    }
}
