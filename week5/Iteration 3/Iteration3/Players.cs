using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Iteration3
{
    public class Player(string name, string desc) : GameObject(idents, name, desc)
    {
        private readonly Inventory _inventory = new();
        private static readonly string[] idents = ["me", "inventory"];

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
                return "You are " + Name + ", " + base.FullDescription + ".\nYou are carrying:\n" + _inventory.ItemList;
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
