using FormHabit.Models;
using System.Collections.ObjectModel;

namespace FormHabit.ViewModels
{
    public class HabitViewModel : ViewModelBase
    {
        private ObservableCollection<Event> _allEvents { get; set; }

        public ObservableCollection<Event> AllEvents
        {
            set
            {
                _allEvents = value;
                OnPropertyChanged();
            }

            get
            {
                return _allEvents;
            }
        }
    }
}
