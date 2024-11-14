using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration8
{
    public class Path(string[] idents, string name, string desc, Location source, Location destination) : GameObject(idents, name, desc)
    {
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
    }
}