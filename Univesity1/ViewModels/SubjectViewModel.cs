using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniversityApp.Data;
using UniversityApp.Models;

namespace UniversityApp.WPF.ViewModels
{
    public class SubjectsViewModel : BaseViewModel
    {
        public ObservableCollection<Subject> Subjects { get; set; }

        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }

        public SubjectsViewModel()
        {
            using var db = new AppDbContext();
            Subjects = new ObservableCollection<Subject>(db.Subjects.Any() ? db.Subjects.ToList() : new List<Subject>());
        }
    }
}
