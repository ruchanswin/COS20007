using System;

namespace Iteration7
{
    public class Look : Command
    {
        public Look() : base(["look"])
        {

        }

        private static IHaveInventory? FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private static string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject foundItem = container.Locate(thingId);
            if (foundItem == null)
            {
                if (container == container.Locate("inventory"))
                {
                    return $"I can't find {thingId}";
                }
                else
                {
                    return $"I can't find {thingId} in the {container.Name}";
                }
            }
            return foundItem.FullDescription;
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory? container = p;
            string error = "I don't know how to look like that";
            string error1 = "Error in look input";
            string error2 = "What do you want to look at?";
            string error3 = "What do you want to look in?";

            if (text.Length == 1 && text[0].Equals("look", StringComparison.CurrentCultureIgnoreCase))
            {
                return $"You are in the {p.Location.Name}, {p.Location.FullDescription}{p.Location.PathList}";
            }

            if (text.Length != 3 && text.Length != 5)
            {
                return error;
            }

            if (!text[0].Equals("look", StringComparison.CurrentCultureIgnoreCase))
            {
                return error1;
            }

            if (!text[1].Equals("at", StringComparison.CurrentCultureIgnoreCase))
            {
                return error2;
            }

            if (text.Length == 5)
            {
                if (!text[3].Equals("in", StringComparison.CurrentCultureIgnoreCase))
                    return error3;

                container = FetchContainer(p, text[4]);
                if (container == null)
                    return $"I can't find the {text[4]}";
            }
            return LookAtIn(text[2], container);
        }
    }
}