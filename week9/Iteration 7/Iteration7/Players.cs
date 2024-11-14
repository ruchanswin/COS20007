using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Iteration7
{
    public class Player(string name, string desc) : GameObject(["me", "inventory"], name, desc), IHaveInventory
    {
        private readonly Inventory _inventory = new();
        private Location _sourcelocation;
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

        public Location SourceLocation
        {
            get
            {
                return _sourcelocation;
            }

            set
            {
                _sourcelocation = value;
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

        public void Move(Path path)
        {
            if (path.Destination != null)
            {
                _sourcelocation = path.Source;
                _location = path.Destination;
            }
        }
    }
}