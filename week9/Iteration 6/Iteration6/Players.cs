using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Iteration6
{
    public class Player(string name, string desc) : GameObject(["me", "inventory"], name, desc), IHaveInventory
    {
        private readonly Inventory _inventory = new();
        private Location _location;

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if (_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public override string FullDescription
        {
            get
            {
                return "You are " + Name + ", a " + base.FullDescription + ".\nYou are carrying:\n" + _inventory.ItemList;
            }
        }
   
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get 
            {
                return _location;
            } 

            set
            {
                _location = value;
            }
        }
    }
}