using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FormHabit.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FormHabit.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalenderView : Page
    {
        public ViewModels.CalenderViewModel ViewModel { get; set; }

        public CalenderView()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) =>
            {
                ViewModel = DataContext as ViewModels.CalenderViewModel;
            };

        }

        private void AddEventConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameBlock.Text.Length != 0)
            {
                Event singleEvent = new Event();
                singleEvent.title = nameBlock.Text;
                
                if (repeatToggle.IsOn)
                {
                    
                }

                if (durationToggle.IsOn)
                {
                    singleEvent.expectDuration = durationPicker.Time;
                }

                if (startToggle.IsOn)
                {
                    singleEvent.startTime = startTimePicker.Date.Date;
                }

                Core.CoreData.allEvents.Add(singleEvent);

                
                    List<Event> todayEvents = Core.CoreData.GetEventsByDay(CalView.SelectedDates[0].Date);

                    if (todayEvents != null)
                    {
                        ViewModel.TodayEventsCollcetion = new ObservableCollection<Event>(todayEvents);
                    }
                

                addButtonFlyout.Hide();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CalView.SelectedDates.Add(DateTime.Now);
        }

        private void CalView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            if (sender.SelectedDates != null && sender.SelectedDates[0] != null)
            {
                List<Event> todayEvents = Core.CoreData.GetEventsByDay(sender.SelectedDates[0].Date);

                if (todayEvents != null)
                {
                    ViewModel.TodayEventsCollcetion = new ObservableCollection<Event>(todayEvents);
                }
            }
        }

        //private void ShowMenu(bool isTransient, UIElement sender)
        //{
        //    FlyoutShowOptions myOption = new FlyoutShowOptions();
        //    myOption.ShowMode = isTransient ? FlyoutShowMode.Transient : FlyoutShowMode.Standard;
        //    CommandBarFlyout1.ShowAt(sender, myOption);
        //}


        //private void CalListView_ContextRequested(UIElement sender, Windows.UI.Xaml.Input.ContextRequestedEventArgs args)
        //{
        //    ShowMenu(true, sender);
        //}

        private void CalListView_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            var framework = (FrameworkElement)e.OriginalSource;
            Object dataContext = framework.DataContext;

            if (dataContext != null && framework.GetType() == typeof(ListViewItemPresenter))
            {
                CommandBarFlyout1.ShowAt(framework);
            }
        }
    }
}
