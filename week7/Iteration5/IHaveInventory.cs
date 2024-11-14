using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration5
{
    interface IHaveInventory
    {
        GameObject Locate(string id);
        string Name
        {
            get;
        }
    }
}
