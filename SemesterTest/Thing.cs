using System;

namespace SemesterTest
{
    public abstract class Thing
    {
        private string _name;
        private string _number;

        public Thing(string number, string name)
        {
            _name = name;
            _number = number;
        }

        public abstract void Print();

        public abstract decimal Total();

        public string Number
        {
            get
            {
                return _number;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
