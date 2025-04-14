using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniversityApp.Data;
using UniversityApp.Models;

namespace UniversityApp.WPF.ViewModels
{
    public class GroupsViewModel : BaseViewModel
    {
        public ObservableCollection<Group> Groups { get; set; }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged();
            }
        }

        public GroupsViewModel()
        {
            using var db = new AppDbContext();
            Groups = new ObservableCollection<Group>(db.Groups.Any() ? db.Groups.ToList() : new List<Group>());
        }
    }
}
