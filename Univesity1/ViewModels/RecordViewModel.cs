using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using UniversityApp.Data;
using UniversityApp.Models;

namespace UniversityApp.WPF.ViewModels
{
    public class RecordViewModel : BaseViewModel
    {
        public ObservableCollection<Record> Records { get; set; }

        private Record _selectedRecord;
        public Record SelectedRecord
        {
            get => _selectedRecord;
            set
            {
                _selectedRecord = value;
                OnPropertyChanged();
            }
        }

        public RecordViewModel()
        {
            using var db = new AppDbContext();
            Records = new ObservableCollection<Record>(
                db.Records
                  .Include(r => r.Subject)
                  .ToList()
            );
        }
    }
}
