using System;
using System.Collections.Generic;
using System.Drawing;

namespace FormHabit.Models
{
    public enum EventType
    {
        Regular = 0,
        Routine = 1,
        Habit = 2
    }

    public enum Day
    {
        Mon = 0,
        Tue = 1,
        Wed = 2,
        Thu = 3,
        Fri = 4,
        Sat = 5,
        Sun = 6
    }

    public class Event
    {
        public string title { get; set; }
        public string note { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isRepeat { get; set; }
        public List<DayOfWeek> repeatDays { get; set; }
        public TimeSpan expectDuration { get; set; }
        public TimeSpan realDuration { get; set; }
        public string check { get; set; }
        public EventType eventType { get; set; }
        public Color color { get; set; }
        public int repeatTimes = 0;
        public int totalMin = 0;

        public int goalNumDay = 0;

        public int numOfDayFinished = 0;

        public int numOfDayTarget = 0;

        public int avgTime
        {
            get
            {
                if (repeatTimes != 0)
                {
                    return totalMin / repeatTimes;
                }

                return 0;
            }
        }

        public int percentage
        {
            get
            {
                if (numOfDayTarget != 0)
                {
                    return numOfDayFinished / numOfDayTarget;
                }

                return 0;
            }
        }
    }
}
