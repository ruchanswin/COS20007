using System;

namespace SemesterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sales book_sales = new Sales();

            //Add first batch order
            Batch b1 = new Batch("#2024x00001", "CompSci Books");

            b1.Add(new Transaction("1", "Deep Learning in Python", 67.90m));
            b1.Add(new Transaction("2", "C# in Action", 54.10m));
            b1.Add(new Transaction("3", "Design Patterns", 129.75m));
            book_sales.Add(b1);

            //Add second batch order
            Batch b2 = new Batch("#2024x00002", "Fantasy Books");

            b2.Add(new Transaction("1", "Harry Potter and the Philosopher's stone", 15.00m));
            b2.Add(new Transaction("2", "Lord of the rings", 25.00m));
            book_sales.Add(b2);

            //Add single orders 
            book_sales.Add(new Transaction("00-0001", "Compilers", 134.60m));
            book_sales.Add(new Transaction("10-0003", "Hunger Games 1-3", 45.00m));
            book_sales.Add(new Transaction("15-0020", "Learning Blender", 56.90m));

            //Add empty order 
            Batch b3 = new Batch("", "Empty order");

            //Add nested order

            Batch nested_order = new Batch("#2024x00003", "Nested order");
            nested_order.Add(b1);
            nested_order.Add(b2);
            book_sales.Add(nested_order);

            book_sales.PrintOrders();


        }
    }
}
