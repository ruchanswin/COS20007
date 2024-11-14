using System;
namespace HelloWorld;

internal class Program
{
    static void Main(string[] args)
    {
        Message myMessage;
        string[] messages = new string[5];

        myMessage = new Message("Hello, World! Greetings from Message Object.");
        myMessage.Print();

        messages[0] = "Hi Minh, how are you?";
        messages[1] = "Hi Wilma, how are you?";
        messages[2] = "Hi Alex, how are you?";
        messages[3] = "It's my pleasure to meet you.";

        Console.Write("Enter name: ");
        string name = Console.ReadLine().ToLower();

        if (name == "minh")
        {
            Console.WriteLine(messages[0]);
        }
        else if (name == "wilma")
        {
            Console.WriteLine(messages[1]);
        }
        else if (name == "alex")
        {
            Console.WriteLine(messages[2]);
        }
        else
        {
            Console.WriteLine(messages[3]);
        }
        Console.ReadLine();
    }
}
