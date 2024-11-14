using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration4
{
    public class GameObject(string[] idents, string name, string desc) : IdentifiableObject(idents)
    {
        private readonly string _description = desc;
        private readonly string _name = name;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string ShortDescription
        {
            get
            {
                return "a " + _name + " " + FirstID;
            }
        }
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }
    }
}