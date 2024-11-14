using System;

namespace SemesterTest
{
        public class Transaction : Thing
        {
            private decimal _amount;

            public Transaction(string number, string name, decimal amount) : base(number, name)
            {
                _amount = amount;
            }

            public override void Print()
            {
                Console.WriteLine($"#{Number}, {Name}, ${_amount}");
            }

            public override decimal Total()
            {
                return _amount;
            }
        }
    }
