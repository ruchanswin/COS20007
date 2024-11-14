using System;
using System.Collections.Generic;

namespace Iteration8
{
    public class IdentifiableObject
    {
        private readonly List<string> _idents = [];

        public IdentifiableObject(string[] idents)
        {
            foreach (string s in idents)
            {
                AddIdentifier(s);
            }
        }

        public bool AreYou(string id)
        {
            return _idents.Contains(id.ToLower());
        }

        public string FirstID
        {
            get
            {
                if (_idents.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _idents[0];
                }
            }
        }

        public void AddIdentifier(string id)
        {
            _idents.Add(id.ToLower());
        }
    }
}
