using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2TimeClock
{
    public class Time
    {

        public TimeSpan TimeNow { get; set; }
        public Time(TimeSpan time)
        {
            TimeNow = time;
        }

        public void Print()
        {
            Console.WriteLine($"{TimeNow.Hours}:{TimeNow.Minutes}:{TimeNow.Seconds}:{TimeNow.Milliseconds}");
        }


        public TimeSpan Add(TimeSpan time)
        {
            return new TimeSpan(TimeNow.Hours + time.Hours, TimeNow.Minutes + time.Minutes, TimeNow.Seconds + time.Seconds, TimeNow.Milliseconds + TimeNow.Milliseconds);
        }

        public TimeSpan Remove(TimeSpan time)
        {
            return new TimeSpan(TimeNow.Hours - time.Hours, TimeNow.Minutes - time.Minutes, TimeNow.Seconds - time.Seconds, TimeNow.Milliseconds - TimeNow.Milliseconds);
        }

        public void Sort(List<TimeSpan> times)
        {
            Dictionary<TimeSpan, int> mapTimes = new Dictionary<TimeSpan, int>();
            times.ForEach(t => mapTimes.Add(t, ConvertTimeSpanToMilisecend(t)));
            var timesOrderBy = mapTimes.OrderBy(t => t.Value);
            foreach (var item in timesOrderBy)
                Console.WriteLine($"{item.Key.Hours}:{item.Key.Minutes}");
        }

        private int ConvertTimeSpanToMilisecend(TimeSpan time)
        {

            return time.Hours * 60 * 60 * 1000 +
                         time.Minutes * 60 * 1000 +
                         time.Seconds * 1000 +
                         time.Milliseconds;
        }

        public static bool operator ==(Time time, Time time2)
        {
            return time.TimeNow.Hours == time2.TimeNow.Hours &&
                time.TimeNow.Minutes == time2.TimeNow.Minutes &&
                time.TimeNow.Seconds == time2.TimeNow.Seconds &&
                time.TimeNow.Milliseconds == time2.TimeNow.Milliseconds;
        }



        public static bool operator !=(Time obj1, Time obj2)
        {
            return !(obj1 == obj2);

        }

    }
}