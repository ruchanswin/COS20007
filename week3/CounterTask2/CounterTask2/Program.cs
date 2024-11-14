
using System;
using System.Threading;

namespace CounterTask2
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock();
            int i;

            for (i = 0; i < 86400; i++)
            {
                Thread.Sleep(200);
                Console.Clear();
                clock.Tick();
                Console.WriteLine(clock.Time());
            }
        }
    }
}
