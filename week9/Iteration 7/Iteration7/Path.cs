using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration7
{
    public class Path(string[] idents, string name, string desc, Location source, Location destination) : GameObject(idents, name, desc)
    {
        bool _isBlocked = false;
        private readonly Location _source = source;
        private readonly Location _destination = destination;

        public Location Source
        {
            get
            {
                return _source;
            }
        }

        public Location Destination
        {
            get 
            { 
                return _destination; 
            }
        }

        public bool IsBlocked
        {
            get 
            { 
                return _isBlocked; 
            }
            set 
            { 
                _isBlocked = value; 
            }
        }
    }
}