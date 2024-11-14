using System;
using System.Collections.Generic;

namespace Iteration2
{
    public class IDObject
    {
        private readonly List<string> _ids = [];

        public IDObject(string[] ids)
        {
            foreach (string s in ids)
            {
                AddID(s);
            }
        }

        public bool AreYou(string id)
        {
            return _ids.Contains(id.ToLower());
        }

        public string FirstID
        {
            get
            {
                if (_ids.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _ids[0];
                }
            }
        }

        public void AddID(string id)
        {
            _ids.Add(id.ToLower());
        }
    }
}
