using System;

namespace SemesterTest
{
    public class Sales
    {
        private List<Thing> _orders;

        public Sales()
        {
            _orders = new List<Thing>();
        }

        public void Add(Thing thing)
        {
            _orders.Add(thing);
        }

        public void PrintOrders()
        {
            Console.WriteLine("Sales: ");
            decimal total_orders = 0;

            foreach (Thing thing in _orders)
            {
                thing.Print();
                Console.WriteLine("Total: $" + thing.Total());
                total_orders = total_orders + thing.Total();
            }

            Console.WriteLine("Total sales: $" + total_orders.ToString());
        }

    }
}
