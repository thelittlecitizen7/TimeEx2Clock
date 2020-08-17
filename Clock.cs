using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2TimeClock
{
    public sealed class Clock
    {
        private static Time _clock { get; set; }

        public static Time GetInstance(TimeSpan time)
        {
            if (_clock == null)
            {
                _clock = new Time(time);
            }
            return _clock;
        }

    }
}
