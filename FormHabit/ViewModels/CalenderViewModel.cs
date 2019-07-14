using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormHabit.Models;

namespace FormHabit.ViewModels
{
    public class CalenderViewModel : ViewModelBase
    {
        private ObservableCollection<Event> _todayEventsCollection { get; set; }

        public ObservableCollection<Event> TodayEventsCollcetion
        {
            set
            {
                _todayEventsCollection = value;
                OnPropertyChanged();
            }

            get
            {
                return _todayEventsCollection;
            }
        }
    }
}
