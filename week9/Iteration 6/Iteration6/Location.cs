using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration6
{
    public class Location(string[] idents, string name, string desc) : GameObject(idents, name, desc), IHaveInventory
    {
        private readonly Inventory _inventory = new();

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}\n\nItems available:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get 
            { 
                return _inventory; 
            }
        }
    }
}