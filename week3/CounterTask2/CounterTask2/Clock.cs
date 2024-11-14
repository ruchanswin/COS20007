using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTask2
{
    public class Clock
    {
        readonly Counter _seconds = new("seconds");
        readonly Counter _minutes = new("minutes");
        readonly Counter _hours = new("hours");

        public Clock()
        {

        }
        public void Tick()
        {
            _seconds.Increment();
            if (_seconds.Tick > 59)
            {
                _minutes.Increment();
                _seconds.Reset();
                if (_minutes.Tick > 59)
                {
                    _hours.Increment();
                    _minutes.Reset();
                    if (_hours.Tick > 23)
                    {
                        Reset();
                    }
                }
            }
        }

        public void Reset()
        {
            _seconds.Reset();
            _minutes.Reset();
            _hours.Reset();
        }

        public string Time()
        {
            return _hours.Tick.ToString("D2") + ":" + _minutes.Tick.ToString("D2") + ":" + _seconds.Tick.ToString("D2");
        }

    }
}