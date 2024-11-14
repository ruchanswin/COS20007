using System;

namespace Iteration5
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
            Item potion1;
            Item potion2;
            Command lookcommand;
            string input = "";

            Console.WriteLine("Press Q To Exit \n");
            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();
            Console.WriteLine($"Hi {name}, What is your occupation?");
            string description = Console.ReadLine();
            Console.WriteLine($"You are {name}, a {description}. Welcome to PaboLand.");

            player = new Player(name, description);

            bag = new Bag(["bag"], "leather bag", "a light bag, suitable for short trips");
            backpack = new Bag(["backpack"], "fabric backpack", "a medium-sized backpack, suitable for abroad travelling");

            sword = new Item(["sword"], "diamond sword", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold shield", "a gold shield that lasts a lifetime");
            potion1 = new Item(["potion"], "healing potion", "a healing potion which is needed for adventurers");
            potion2 = new Item(["potion"], "poison potion", "a dangerous potion for dragons");

            lookcommand = new Look();

            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
            player.Inventory.Put(bag);
            player.Inventory.Put(potion1);
            player.Inventory.Put(backpack);

            bag.Inventory.Put(potion2);
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
