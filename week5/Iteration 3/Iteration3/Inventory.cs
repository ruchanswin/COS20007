using System;
using System.Collections.Generic;

namespace Iteration3
{
    public class Inventory
    {
        private readonly List<Item> _items;

        public Inventory()
        {
            _items = [];
        }

        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public Item Take(string id)
        {
            Item takeitem = Fetch(id);
            _items.Remove(takeitem);
            return takeitem;
        }

        public string ItemList
        {
            get
            {
                string list = "";
                foreach (Item item in _items)
                {
                    list += "\t" + item.ShortDescription + "\n";
                }
                return list;
            }
        }
    }
}
