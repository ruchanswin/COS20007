using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration8
{
    public class Location(string[] idents, string name, string desc) : GameObject(idents, name, desc), IHaveInventory
    {
        readonly Inventory _inventory = new();
        readonly List<Path> _paths = [];

        public Location(string[] idents, string name, string desc, List<Path> paths) : this(idents, name, desc)
        {
            _paths = paths;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                if (_inventory != null)
                {
                    return $"{base.FullDescription}.\nItems available:\n{_inventory.ItemList}";
                }
                return "There are no items here.";
            }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public string PathList
        {
            get
            {
                if (_paths.Count == 0)
                {
                    return "\nThere are no exits.";
                }
                else
                {
                    string list = "\nThere are exits to the ";
                    foreach (Path path in _paths)
                    {
                        list += path.FirstID + ", ";
                    }
                    list = list.TrimEnd(',', ' ') + ".";
                    return list;
                }
            }
        }
    }
}