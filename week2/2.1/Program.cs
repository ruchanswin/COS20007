namespace QueueApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntegerQueue myQueue = new IntegerQueue();

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);

            Console.WriteLine(myQueue.Count);
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
        }
    }
}
