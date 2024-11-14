using System;

namespace Iteration4
{
    public class Look : Command
    {
        public Look() : base(["look"]) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
                return "I don't know how to look like that";

            if (!text[0].Equals("look", StringComparison.CurrentCultureIgnoreCase))
            {
                return "Error in look input";
            }

            if (!text[1].Equals("at", StringComparison.CurrentCultureIgnoreCase))
            {
                return "What do you want to look at?";
            }

            IHaveInventory container = p;
            if (text.Length == 5)
            {
                if (!text[3].Equals("in", StringComparison.CurrentCultureIgnoreCase))
                    return "What do you want to look in?";

                container = FetchContainer(p, text[4]);
                if (container == null)
                    return $"I can't find the {text[4]}";
            }

                return LookAtIn(text[2], container);

        }

        private static IHaveInventory FetchContainer(Player p, string containerId)
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
                    return $"I can't find the {thingId}";
                }
                else
                {
                    return $"I can't find the {thingId} in the {container.Name}";
                }
            }
            return foundItem.FullDescription;
        }
    }
}