using FormHabit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormHabit.Core
{
    public class CoreData
    {
        public static List<Event> allEvents = new List<Event>();

        public static List<Event> GetTodayEvents()
        {

            if (allEvents != null)
            {
                return allEvents.Where(a => (a.startTime.Year == DateTime.Now.Year && a.startTime.DayOfYear == DateTime.Now.DayOfYear) || (a.isRepeat && a.repeatDays.Contains(DateTime.Now.DayOfWeek))).ToList();
            }

            return null;

        }

        public static List<Event> GetEventsByDay(DateTime dateTime)
        {
            if (allEvents != null)
            {
                return allEvents.Where(a => a.startTime.Year == dateTime.Year && a.startTime.DayOfYear == dateTime.DayOfYear).ToList();
            }

            return null;
        }
    }
}
