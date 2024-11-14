using System;

namespace Iteration6
{
    public class Interface
    {
        static void Main(string[] args)
        {
            Player player;
            Bag bag;
            Bag backpack;

            Item sword;
            Item shield;
            Item potion;
            Item gem;

            Location garage;

            Item monitor;
            Item computer;
            Item phone;

            Command lookcommand;
            string input = "";

            Console.WriteLine("Press Q to Exit \n");
            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();
            Console.WriteLine($"Hi {name}, What is your occupation?");
            string description = Console.ReadLine();
            player = new Player(name, description);
            garage = new Location(["garage"], "big garage", "a room where items are stored");
            player.Location = garage;
            Console.WriteLine($"You are {name}, a {description}. Welcome to the {player.Location.Name}");

            bag = new Bag(["bag"], "leather bag", "a light bag, suitable for short trips");
            backpack = new Bag(["backpack"], "fabric backpack", "a medium-sized backpack, suitable for abroad travelling");

            gem = new Item(["gem"], "gem", "A gem that could be used to trade items.");
            sword = new Item(["sword"], "diamond sword", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold shield", "a gold shield that lasts a lifetime");
            potion = new Item(["potion"], "healing potion", "a healing potion which is needed for adventurers");

            monitor = new Item(["monitor"], "new monitor", "a brand new monitor");
            computer = new Item(["computer"], "public computer", "a computer which is suitable for students");
            phone = new Item(["phone"], "mobile phone", "a phone that is recently sold");

            garage.Inventory.Put(monitor);
            garage.Inventory.Put(computer);
            garage.Inventory.Put(phone);
            player.Location = garage;
            player.Inventory.Put(computer);

            lookcommand = new Look();

            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
            player.Inventory.Put(bag);
            player.Inventory.Put(potion);
            player.Inventory.Put(backpack);

            bag.Inventory.Put(potion);
            backpack.Inventory.Put(sword);
            backpack.Inventory.Put(bag);

            while (input != "q")
            {
                Console.Write("Look command: \n");
                input = Console.ReadLine().ToLower();
                if (input != "q")
                {
                    Console.WriteLine(lookcommand.Execute(player, input.Split()));

                }
                else
                {
                    break;
                }
            }
        }
    }
}
