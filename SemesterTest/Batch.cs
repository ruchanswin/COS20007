using System;

namespace SemesterTest
{
    public class Batch : Thing
    {

        private List<Thing> _items;

        public Batch(string number, string name) : base(number, name)
        {
            _items = new List<Thing>();
        }

        public void Add(Thing thing)
        {
            _items.Add(thing);
        }

        public override void Print()
        {
            Console.WriteLine($"Batch order: {Number}, {Name}");
            foreach (Thing thing in _items)
            {
                thing.Print();
            }
        }

        public override decimal Total()
        {
            decimal amount = 0;
            foreach (Thing thing in _items)
            {
                amount = amount + thing.Total();
            }
            return amount;
        }
    }
}
