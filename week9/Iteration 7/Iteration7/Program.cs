using System;
using System.IO;

namespace Iteration7
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
            Location bedroom;
            Location gamingroom;
            Location livingroom;

            Item monitor;
            Item computer;
            Item phone;

            Command lookcommand;
            Command movecommand;
            string input = "";

            Console.WriteLine("Press Q to Exit \n");
            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();
            Console.WriteLine($"Hi {name}, What is your occupation?");
            string description = Console.ReadLine();
            player = new Player(name, description);

            bedroom = new(["bedroom"], "private bedroom", "a room for private stuff");
            player.Location = bedroom;
            Console.WriteLine($"You are {name}, a {description}. Welcome to the {player.Location.Name}");

            bag = new Bag(["bag"], "leather bag", "a light bag, suitable for short trips");
            backpack = new Bag(["backpack"], "fabric backpack", "a medium-sized backpack, suitable for abroad travelling");

            gem = new Item(["gem"], "gem", "A gem that could be used to trade items.");
            sword = new Item(["sword"], "diamond sword", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold shield", "a gold shield that lasts a lifetime");
            potion = new Item(["potion"], "healing potion", "a healing potion which is needed for adventurers");

            garage = new Location(["garage"], "big garage", "a room where items are stored");
            Path bedroomTogarage = new(["east"], "rolling door", "Walk through rolling door", bedroom, garage);
            Path garageTobedroom = new(["west"], "rolling door", "Walk through rolling door", garage, bedroom);
            bedroom.AddPath(bedroomTogarage);
            garage.AddPath(garageTobedroom);

            monitor = new Item(["monitor"], "new monitor", "a brand new monitor");
            computer = new Item(["computer"], "public computer", "a computer which is suitable for students");
            phone = new Item(["phone"], "mobile phone", "a phone that is recently sold");
            Item tablet = new (["tablet"], "IMac", "an expensive tablet");
            Item mouse = new(["mouse"], "wireless mouse", "a mouse that is bought on EBay");
            Item TV = new(["TV"], "Samsung TV", "a TV that hasn't been used much");

            garage.Inventory.Put(phone);
            player.Inventory.Put(computer);

            lookcommand = new Look();
            movecommand = new Move();

            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
            player.Inventory.Put(bag);
            player.Inventory.Put(potion);
            player.Inventory.Put(backpack);

            bag.Inventory.Put(potion);
            backpack.Inventory.Put(sword);
            backpack.Inventory.Put(bag);

            gamingroom = new(["gamingroom"], "large gamingroom", "a room for relaxation");
            Path bedroomTogamingroom = new(["north"], "door", "Go through door", bedroom, gamingroom);
            Path gamingroomTobedroom = new(["south"], "door", "Go through door", gamingroom, bedroom);
            bedroom.AddPath(bedroomTogamingroom);
            gamingroom.AddPath(gamingroomTobedroom);

            livingroom = new(["livingroom"], "family livingroom", "a room for family talk");
            Path bedroomTolivingroom = new(["down"], "door", "Go through door", bedroom, livingroom);
            Path livingroomTobedroom = new(["up"], "door", "Go through door", livingroom, bedroom);
            bedroom.AddPath(bedroomTolivingroom);
            livingroom.AddPath(livingroomTobedroom);

            gamingroom.Inventory.Put(monitor);
            gamingroom.Inventory.Put(computer);
            bedroom.Inventory.Put(gem);
            bedroom.Inventory.Put(mouse);
            livingroom.Inventory.Put(tablet);
            livingroom.Inventory.Put(TV);

            while (input != "q")
            {
                Console.Write("Command: \n");
                input = Console.ReadLine().Trim();

                if (input == "q")
                {
                    break;
                }

                List<string> checkmovecommand = ["move", "go", "head", "leave"];
                List<string> checkcommand = ["move", "go", "head", "leave", "look"];

                string error = "Error in command input.";

                if (input.Split()[0].Equals("look", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine(lookcommand.Execute(player, input.Split()));
                }
                if (checkmovecommand.Contains(input.Split()[0].ToLower()))
                {
                    Console.WriteLine(movecommand.Execute(player, input.Split()));
                }
                if (!checkcommand.Contains(input.Split()[0].ToLower()))
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}
