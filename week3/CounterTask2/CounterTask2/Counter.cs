using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTask2
{
    public class Counter(string name)
    {
        private int _count = 0;
        private string _name = name;

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Tick
        {
            get
            {
                return _count;
            }
        }
    }
}

