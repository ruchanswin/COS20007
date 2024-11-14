using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration5
{
    public abstract class Command(string[] ids) : IdentifiableObject(ids)
    {
        public abstract string Execute(Player p, string[] text);
    }
}

